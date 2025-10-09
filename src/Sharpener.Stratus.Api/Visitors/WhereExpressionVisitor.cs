// The Sharpener project licenses this file to you under the MIT license.

using System.Linq.Expressions;
using System.Text;
using Sharpener.Stratus.Api.Extensions;

namespace Sharpener.Stratus.Api.Visitors;

/// <summary>
///     Converts C# lambda expressions to custom query string syntax.
/// </summary>
public class WhereExpressionVisitor : ExpressionVisitor
{
    private readonly StringBuilder _queryBuilder = new();

    /// <summary>
    ///     Converts a lambda expression to a query string.
    /// </summary>
    public static string ToQueryString<T>(Expression<Func<T, bool>> expression)
    {
        var visitor = new WhereExpressionVisitor();
        visitor.Visit(expression);
        return visitor._queryBuilder.ToString();
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        Visit(node.Left);

        var op = node.NodeType switch
        {
            ExpressionType.Equal => " eq ",
            ExpressionType.NotEqual => " ne ",
            ExpressionType.GreaterThan => " gt ",
            ExpressionType.GreaterThanOrEqual => " ge ",
            ExpressionType.LessThan => " lt ",
            ExpressionType.LessThanOrEqual => " le ",
            ExpressionType.AndAlso => " AND ",
            ExpressionType.OrElse => " OR ",
            _ => throw new NotSupportedException($"Binary operator {node.NodeType} is not supported")
        };

        _queryBuilder.Append(op);
        Visit(node.Right);

        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression is { NodeType: ExpressionType.Parameter })
        {
            // This is a property access like "project.Name"
            _queryBuilder.Append(node.Member.Name.ToCamelCase());
        }
        else if (node.Expression != null)
        {
            // This might be accessing a static property like DateTime.Now
            var objectMember = Expression.Convert(node, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            var value = getter();
            AppendValue(value);
        }

        return node;
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        // Handle instance methods like String.StartsWith, String.Contains, etc.
        if (node.Object is { NodeType: ExpressionType.MemberAccess })
        {
            Visit(node.Object); // Visit the property (e.g., "Name")

            var methodName = node.Method.Name.ToCamelCase();
            _queryBuilder.Append($".{methodName}(");

            // Add arguments
            for (var i = 0; i < node.Arguments.Count; i++)
            {
                if (i > 0)
                {
                    _queryBuilder.Append(", ");
                }

                Visit(node.Arguments[i]);
            }

            _queryBuilder.Append(')');
        }
        // Handle static methods like DateTime.Now.AddDays(-30)
        else if (node.Object != null)
        {
            // Evaluate the entire method call
            var objectMember = Expression.Convert(node, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            var value = getter();

            if (value is DateTime dt)
            {
                _queryBuilder.Append($"DateTime.Parse('{dt:O}')");
            }
            else
            {
                AppendValue(value);
            }
        }
        else
        {
            // Try to evaluate the method call
            try
            {
                var objectMember = Expression.Convert(node, typeof(object));
                var getterLambda = Expression.Lambda<Func<object>>(objectMember);
                var getter = getterLambda.Compile();
                var value = getter();

                if (value is DateTime dt)
                {
                    _queryBuilder.Append($"DateTime.Parse('{dt:O}')");
                }
                else
                {
                    AppendValue(value);
                }
            }
            catch
            {
                throw new NotSupportedException($"Method {node.Method.Name} is not supported in this context");
            }
        }

        return node;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        AppendValue(node.Value);
        return node;
    }

    protected override Expression VisitUnary(UnaryExpression node)
    {
        switch (node.NodeType)
        {
            // Handle conversions and negations
            case ExpressionType.Not:
                _queryBuilder.Append("NOT ");
                break;
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                break;
            default:
                throw new NotSupportedException($"Unary operator {node.NodeType} is not supported");
        }

        Visit(node.Operand);

        return node;
    }

    private void AppendValue(object? value)
    {
        switch (value)
        {
            case null:
                _queryBuilder.Append("null");
                break;
            case string str:
                _queryBuilder.Append($"'{str.Replace("'", "''")}'"); // Escape single quotes
                break;
            case DateTime dt:
                _queryBuilder.Append($"DateTime.Parse('{dt:O}')");
                break;
            case bool b:
                _queryBuilder.Append(b ? "true" : "false");
                break;
            case int:
            case long:
            case decimal:
            case double:
            case float:
                _queryBuilder.Append(value);
                break;
            default:
                _queryBuilder.Append($"'{value}'");
                break;
        }
    }
}
