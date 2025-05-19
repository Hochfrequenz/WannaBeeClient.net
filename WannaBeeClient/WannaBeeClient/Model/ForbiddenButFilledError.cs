using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record ForbiddenButFilledError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "ForbiddenButFilledError";
}
