using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record HTTPValidationError(
    [property: JsonPropertyName("detail")] IReadOnlyList<ValidationErrorDetail> Detail
);
