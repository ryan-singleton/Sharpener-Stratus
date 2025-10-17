// using System.Linq.Expressions;
// using Sharpener.Stratus.Api.Visitors;
// using Xunit;
//
// namespace Sharpener.Stratus.Api.Tests.Visitors;
//
// public class WhereExpressionVisitorTests
// {
//     #region Method Calls with Multiple Arguments
//
//     [Fact]
//     public void MethodCall_WithTwoArguments_GeneratesCorrectSyntax()
//     {
//         // Note: This would require a custom method on your model or extension method
//         // Using a realistic example with string methods that could have overloads
//         Expression<Func<TestModel, bool>> expr = x => x.Name.Substring(0, 3) == "Foo";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name.Substring(0, 3) eq 'Foo'", result);
//     }
//
//     #endregion
//
//     // Test model
//     private class TestModel
//     {
//         public string Name { get; set; }
//         public int Length { get; set; }
//         public string Description { get; set; }
//         public DateTime CreatedDT { get; set; }
//         public int Priority { get; set; }
//         public bool IsActive { get; set; }
//         public decimal Price { get; set; }
//         public long LongValue { get; set; }
//         public double DoubleValue { get; set; }
//         public float FloatValue { get; set; }
//     }
//
//     #region Binary Operators - Equality
//
//     [Fact]
//     public void Equal_StringProperty_GeneratesEqOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name == "Foo";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name eq 'Foo'", result);
//     }
//
//     [Fact]
//     public void Equal_IntProperty_GeneratesEqOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Length == 10;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("length eq 10", result);
//     }
//
//     [Fact]
//     public void NotEqual_StringProperty_GeneratesNeOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name != "Bar";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name ne 'Bar'", result);
//     }
//
//     #endregion
//
//     #region Binary Operators - Comparison
//
//     [Fact]
//     public void GreaterThan_IntProperty_GeneratesGtOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Priority > 5;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("priority gt 5", result);
//     }
//
//     [Fact]
//     public void GreaterThanOrEqual_IntProperty_GeneratesGeOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Priority >= 5;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("priority ge 5", result);
//     }
//
//     [Fact]
//     public void LessThan_IntProperty_GeneratesLtOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Priority < 10;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("priority lt 10", result);
//     }
//
//     [Fact]
//     public void LessThanOrEqual_IntProperty_GeneratesLeOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Priority <= 10;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("priority le 10", result);
//     }
//
//     #endregion
//
//     #region Logical Operators
//
//     [Fact]
//     public void AndAlso_TwoConditions_GeneratesANDOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Length == 10 && x.Description == "truck";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("length eq 10 AND description eq 'truck'", result);
//     }
//
//     [Fact]
//     public void OrElse_TwoConditions_GeneratesOROperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name == "Foo" || x.Priority > 5;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name eq 'Foo' OR priority gt 5", result);
//     }
//
//     [Fact]
//     public void ComplexLogical_MultipleAndOr_GeneratesCorrectQuery()
//     {
//         Expression<Func<TestModel, bool>> expr = x =>
//             (x.Name == "Foo" || x.Name == "Bar") && x.Priority > 3;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name eq 'Foo' OR name eq 'Bar' AND priority gt 3", result);
//     }
//
//     #endregion
//
//     #region String Methods
//
//     [Fact]
//     public void StartsWith_StringProperty_GeneratesMethodCall()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name.StartsWith("Foo");
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name.StartsWith('Foo')", result);
//     }
//
//     [Fact]
//     public void Contains_StringProperty_GeneratesMethodCall()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Description.Contains("test");
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("description.Contains('test')", result);
//     }
//
//     [Fact]
//     public void EndsWith_StringProperty_GeneratesMethodCall()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name.EndsWith("Bar");
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name.EndsWith('Bar')", result);
//     }
//
//     #endregion
//
//     #region DateTime Handling
//
//     [Fact]
//     public void DateTime_StaticNow_EvaluatesAndFormats()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.CreatedDT >= DateTime.Now;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//
//         Assert.StartsWith("createdDT ge DateTime.Parse('", result);
//         Assert.EndsWith("')", result);
//     }
//
//     [Fact]
//     public void DateTime_AddDaysMethod_EvaluatesAndFormats()
//     {
//         var testDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
//         Expression<Func<TestModel, bool>> expr = x => x.CreatedDT >= testDate.AddDays(-30);
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//
//         Assert.Contains("createdDT ge DateTime.Parse('2023-12-02T00:00:00.0000000", result);
//     }
//
//     [Fact]
//     public void DateTime_ConstantValue_FormatsCorrectly()
//     {
//         var specificDate = new DateTime(2024, 6, 15, 10, 30, 0, DateTimeKind.Utc);
//         Expression<Func<TestModel, bool>> expr = x => x.CreatedDT == specificDate;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//
//         Assert.Equal("createdDT eq DateTime.Parse('2024-06-15T10:30:00.0000000Z')", result);
//     }
//
//     #endregion
//
//     #region Value Types
//
//     [Fact]
//     public void Boolean_TrueValue_GeneratesTrue()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.IsActive == true;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("isActive eq true", result);
//     }
//
//     [Fact]
//     public void Boolean_FalseValue_GeneratesFalse()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.IsActive == false;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("isActive eq false", result);
//     }
//
//     [Fact]
//     public void Decimal_Value_GeneratesNumber()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Price == 99.99m;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("price eq 99.99", result);
//     }
//
//     [Fact]
//     public void Long_Value_GeneratesNumber()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.LongValue == 1000000000L;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("longValue eq 1000000000", result);
//     }
//
//     [Fact]
//     public void Double_Value_GeneratesNumber()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.DoubleValue == 3.14159;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("doubleValue eq 3.14159", result);
//     }
//
//     [Fact]
//     public void Float_Value_GeneratesNumber()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.FloatValue == 2.5f;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Contains("floatValue eq 2.5", result);
//     }
//
//     #endregion
//
//     #region String Escaping
//
//     [Fact]
//     public void String_WithSingleQuote_EscapesQuote()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name == "O'Brien";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name eq 'O''Brien'", result);
//     }
//
//     [Fact]
//     public void String_WithMultipleSingleQuotes_EscapesAllQuotes()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Description == "It's a '90s thing";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("description eq 'It''s a ''90s thing'", result);
//     }
//
//     #endregion
//
//     #region Null Handling
//
//     [Fact]
//     public void NullComparison_GeneratesNullKeyword()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name == null;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name eq null", result);
//     }
//
//     [Fact]
//     public void NotNullComparison_GeneratesNullKeyword()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Description != null;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("description ne null", result);
//     }
//
//     #endregion
//
//     #region Unary Operators
//
//     [Fact]
//     public void Not_BooleanProperty_GeneratesNOTOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => !x.IsActive;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("NOT isActive", result);
//     }
//
//     [Fact]
//     public void Not_ComplexExpression_GeneratesNOTOperator()
//     {
//         Expression<Func<TestModel, bool>> expr = x => !(x.Priority > 5);
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("NOT priority gt 5", result);
//     }
//
//     #endregion
//
//     #region Edge Cases
//
//     [Fact]
//     public void EmptyString_Comparison_HandlesCorrectly()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Name == "";
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("name eq ''", result);
//     }
//
//     [Fact]
//     public void ZeroValue_Comparison_HandlesCorrectly()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Priority == 0;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("priority eq 0", result);
//     }
//
//     [Fact]
//     public void NegativeValue_Comparison_HandlesCorrectly()
//     {
//         Expression<Func<TestModel, bool>> expr = x => x.Priority == -5;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//         Assert.Equal("priority eq -5", result);
//     }
//
//     #endregion
//
//     #region Unsupported Operations
//
//     [Fact]
//     public void UnsupportedBinaryOperator_ThrowsNotSupportedException()
//     {
//         // Using bitwise AND which isn't in the supported list
//         Expression<Func<TestModel, bool>> expr = x => (x.Priority & 1) == 1;
//
//         var exception = Assert.Throws<NotSupportedException>(() =>
//             WhereExpressionVisitor.ToQueryString(expr));
//
//         Assert.Contains("Binary operator", exception.Message);
//     }
//
//     [Fact]
//     public void UnsupportedUnaryOperator_ThrowsNotSupportedException()
//     {
//         // Using unary minus on a property (not a constant)
//         Expression<Func<TestModel, bool>> expr = x => -x.Priority == 5;
//
//         var exception = Assert.Throws<NotSupportedException>(() =>
//             WhereExpressionVisitor.ToQueryString(expr));
//
//         Assert.Contains("Unary operator", exception.Message);
//     }
//
//     #endregion
//
//     #region Real-World Scenarios
//
//     [Fact]
//     public void RealWorld_FilterLastThirtyDays_GeneratesCorrectQuery()
//     {
//         var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
//         Expression<Func<TestModel, bool>> expr = x => x.CreatedDT >= thirtyDaysAgo;
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//
//         Assert.StartsWith("CreatedDT ge DateTime.Parse('", result);
//     }
//
//     [Fact]
//     public void RealWorld_MultipleFilters_GeneratesCorrectQuery()
//     {
//         Expression<Func<TestModel, bool>> expr = x =>
//             x.Name.StartsWith("Project") &&
//             x.IsActive == true &&
//             x.Priority >= 3;
//
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//
//         Assert.Equal("name.StartsWith('Project') AND isActive eq true AND priority ge 3", result);
//     }
//
//     [Fact]
//     public void RealWorld_SearchWithOR_GeneratesCorrectQuery()
//     {
//         Expression<Func<TestModel, bool>> expr = x =>
//             x.Name.Contains("test") ||
//             x.Description.Contains("test");
//
//         var result = WhereExpressionVisitor.ToQueryString(expr);
//
//         Assert.Equal("name.Contains('test') OR Description.Contains('test')", result);
//     }
//
//     #endregion
// }


