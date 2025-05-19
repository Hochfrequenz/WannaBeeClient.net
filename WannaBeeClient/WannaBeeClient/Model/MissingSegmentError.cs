using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record MissingSegmentError(
    [property: JsonPropertyName("segment")] string Segment,
    [property: JsonPropertyName("index_in_segment_list")] int? IndexInSegmentList,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "MissingSegmentError";
}
