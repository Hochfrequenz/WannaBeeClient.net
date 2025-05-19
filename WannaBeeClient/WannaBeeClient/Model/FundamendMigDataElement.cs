using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendMigDataElement(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("status_std")] MigStatus StatusStd,
    [property: JsonPropertyName("status_specification")] MigStatus StatusSpecification,
    [property: JsonPropertyName("format_std")] string FormatStd,
    [property: JsonPropertyName("format_specification")] string FormatSpecification,
    [property: JsonPropertyName("codes")] IReadOnlyList<FundamendMigCode> Codes
);
