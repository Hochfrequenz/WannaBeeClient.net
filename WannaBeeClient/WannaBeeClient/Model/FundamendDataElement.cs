using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendDataElement(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("ahb_status")] string? AhbStatus,
    [property: JsonPropertyName("codes")] IReadOnlyList<FundamendCode> Codes
);
