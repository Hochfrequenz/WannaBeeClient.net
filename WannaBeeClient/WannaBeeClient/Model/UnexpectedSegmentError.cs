using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record UnexpectedSegmentError(
    [property: JsonPropertyName("index_in_segment_list")] int? IndexInSegmentList,
    [property: JsonPropertyName("expected_segments")]
        IReadOnlyList<FundamendMigSegment> ExpectedSegments,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "UnexpectedSegmentError";
}
