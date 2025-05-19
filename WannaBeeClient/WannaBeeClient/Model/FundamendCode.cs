using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendCode(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("value")] string? Value,
    [property: JsonPropertyName("ahb_status")] string AhbStatus
);
