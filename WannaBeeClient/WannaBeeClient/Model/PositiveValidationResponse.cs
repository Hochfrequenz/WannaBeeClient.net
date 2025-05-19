using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record PositiveValidationResponse([property: JsonPropertyName("valid")] bool Valid = true)
    : ValidationResponse { }
