using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record UnknownCodeError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "UnknownCodeError";
}
