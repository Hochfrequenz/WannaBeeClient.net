namespace AhbichtClient.Model;

/// <summary>
/// the Azure Functions based backend returns this object when an error occurs.
/// Instead of e.g. HTTP Status Code 400, an error object is returned with a status code 200.
/// The status code is only part of the response body in <see cref="Code"/>
/// </summary>
internal class ErrorResponse
{
    /// <summary>
    /// Error message returned by the server / ahbicht backend
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("error")]
    public required string ErrorMessage { get; set; }

    /// <summary>
    /// http status code, e.g 400 for bad request
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("code")]
    public int Code { get; set; }
}
