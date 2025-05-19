using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record Paket(
    [property: JsonPropertyName("nummer")] string Nummer,
    [property: JsonPropertyName("text")] string Text
);
