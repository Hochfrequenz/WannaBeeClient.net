using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record Anwendungsfall(
    [property: JsonPropertyName("pruefidentifikator")] string Pruefidentifikator,
    [property: JsonPropertyName("beschreibung")] string Beschreibung,
    [property: JsonPropertyName("kommunikation_von")] string KommunikationVon,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("elements")] IReadOnlyList<object> Elements
);
