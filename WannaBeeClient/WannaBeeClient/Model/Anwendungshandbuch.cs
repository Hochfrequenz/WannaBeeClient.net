using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record Anwendungshandbuch(
    [property: JsonPropertyName("veroeffentlichungsdatum")] DateOnly Veroeffentlichungsdatum,
    [property: JsonPropertyName("autor")] string Autor,
    [property: JsonPropertyName("versionsnummer")] string Versionsnummer,
    [property: JsonPropertyName("anwendungsfaelle")] IReadOnlyList<Anwendungsfall> Anwendungsfaelle,
    [property: JsonPropertyName("bedingungen")] IReadOnlyList<Bedingung> Bedingungen,
    [property: JsonPropertyName("ub_bedingungen")] IReadOnlyList<UbBedingung> UbBedingungen,
    [property: JsonPropertyName("pakete")] IReadOnlyList<Paket> Pakete
);
