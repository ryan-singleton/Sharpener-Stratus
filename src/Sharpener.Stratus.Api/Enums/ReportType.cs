using System.Text.Json.Serialization;

namespace Sharpener.Stratus.Api.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReportType
{
    Assembly,
    BillOfMaterials,
    Container,
    ContainerDetails,
    Invoice,
    Master,
    Package,
    PackageDetails,
    Part,
    Purchasing,
    ReportAndTemplateConfigurationGrid
}
