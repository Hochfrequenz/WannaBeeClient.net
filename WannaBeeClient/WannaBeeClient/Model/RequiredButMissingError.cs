using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record RequiredButMissingError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("ahb_object")] object AhbObject,
    [property: JsonPropertyName("ahb_object_path")] IReadOnlyList<object> AhbObjectPath,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "RequiredButMissingError";
}
