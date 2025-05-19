using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record IllegalSegmentStructureError(
    [property: JsonPropertyName("ahb_segment")] FundamendSegment AhbSegment,
    [property: JsonPropertyName("mig_segment")] FundamendMigSegment MigSegment,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "IllegalSegmentStructureError";
}
