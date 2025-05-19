using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendMigDataElementGroup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("status_std")] MigStatus StatusStd,
    [property: JsonPropertyName("status_specification")] MigStatus StatusSpecification,
    [property: JsonPropertyName("data_elements")]
        IReadOnlyList<FundamendMigDataElement> DataElements
);
