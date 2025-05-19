using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendSegment(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("number")] string Number,
    [property: JsonPropertyName("ahb_status")] string? AhbStatus,
    [property: JsonPropertyName("data_elements")] IReadOnlyList<object> DataElements
);
