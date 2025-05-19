namespace WannaBeeClient.Model;

using System.Text.Json.Serialization;

// Root Response Models
public record RootResponse(
    [property: JsonPropertyName("message")] string Message = "Welcome to the wannabee API!"
);
