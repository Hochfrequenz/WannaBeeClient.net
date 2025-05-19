using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record ValidationErrorDetail(
    [property: JsonPropertyName("loc")] IReadOnlyList<object> Loc,
    [property: JsonPropertyName("msg")] string Msg,
    [property: JsonPropertyName("type")] string Type
);
