using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendMigSegment(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("counter")] string Counter,
    [property: JsonPropertyName("level")] int Level,
    [property: JsonPropertyName("number")] string Number,
    [property: JsonPropertyName("max_rep_std")] int MaxRepStd,
    [property: JsonPropertyName("max_rep_specification")] int MaxRepSpecification,
    [property: JsonPropertyName("status_std")] MigStatus StatusStd,
    [property: JsonPropertyName("status_specification")] MigStatus StatusSpecification,
    [property: JsonPropertyName("example")] string? Example,
    [property: JsonPropertyName("data_elements")] IReadOnlyList<object> DataElements
);
