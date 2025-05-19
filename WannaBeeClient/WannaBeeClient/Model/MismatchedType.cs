using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record MismatchedType(
    [property: JsonPropertyName("found_type")] string FoundType,
    [property: JsonPropertyName("expected_type")] string ExpectedType,
    [property: JsonPropertyName("location_description")] string LocationDescription,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "MismatchedType";
}
