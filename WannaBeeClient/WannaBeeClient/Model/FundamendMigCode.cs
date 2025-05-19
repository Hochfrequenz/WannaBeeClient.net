using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendMigCode(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("value")] string? Value
);
