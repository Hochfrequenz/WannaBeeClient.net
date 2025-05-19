using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FormatConstraintUnfulfilledError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("format_constraint_error")] string FormatConstraintError,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "FormatConstraintUnfulfilledError";
}
