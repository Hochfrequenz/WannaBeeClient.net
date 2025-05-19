using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record UbBedingung(
    [property: JsonPropertyName("nummer")] string Nummer,
    [property: JsonPropertyName("text")] string Text
);
