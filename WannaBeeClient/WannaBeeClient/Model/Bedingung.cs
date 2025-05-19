using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record Bedingung(
    [property: JsonPropertyName("nummer")] string Nummer,
    [property: JsonPropertyName("text")] string Text
);
