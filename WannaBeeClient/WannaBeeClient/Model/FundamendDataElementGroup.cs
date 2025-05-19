using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record FundamendDataElementGroup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("data_elements")] IReadOnlyList<FundamendDataElement> DataElements
);
