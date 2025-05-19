using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record ValidateEdifactRequest(
    [property: JsonPropertyName("edifact")] string Edifact,
    [property: JsonPropertyName("include_boneycomb_paths")] bool IncludeBoneycombPaths
);
