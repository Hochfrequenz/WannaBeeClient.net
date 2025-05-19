using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record SegmentGroup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("ahb_status")] string? AhbStatus,
    [property: JsonPropertyName("elements")] IReadOnlyList<object> Elements
);
