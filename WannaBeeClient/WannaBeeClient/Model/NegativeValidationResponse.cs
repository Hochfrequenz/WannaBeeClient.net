using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record NegativeValidationResponse(
    [property: JsonPropertyName("errors")] IReadOnlyList<ValidationError> Errors,
    [property: JsonPropertyName("num_errors")] int NumErrors,
    [property: JsonPropertyName("valid")] bool Valid = false
) : ValidationResponse { }
