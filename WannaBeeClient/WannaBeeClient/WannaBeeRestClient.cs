using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WannaBeeClient.Model;
using Version = WannaBeeClient.Model.Version;

namespace WannaBeeClient;

/// <summary>
/// a client for the ahbicht-functions REST API
/// </summary>
public class WannaBeeRestClient : IEdifactAhbValidator
{
    private readonly IWannaBeeAuthenticator _authenticator;
    private readonly HttpClient _httpClient;

    /// <summary>
    /// workaround for
    /// Polymorphic configuration for type 'WannaBeeClient.Model.ValidationResponse' should specify at least one derived type.
    /// </summary>
    private record TrueFalseValid
    {
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }
    }

    /// <summary>
    /// Provide the constructor with a http client factory.
    /// It will create a client from said factory and use the <paramref name="httpClientName"/> for that.
    /// </summary>
    /// <param name="httpClientFactory">factory to create the http client from</param>
    /// <param name="authenticator">something that tells you whether and how you need to authenticate yourself at ahbichtfunctions</param>
    /// <param name="httpClientName">name used to create the client</param>
    public WannaBeeRestClient(
        IHttpClientFactory httpClientFactory,
        IWannaBeeAuthenticator authenticator,
        string httpClientName = "WannaBeeClient"
    )
    {
        _httpClient = httpClientFactory.CreateClient(httpClientName);
        if (_httpClient.BaseAddress == null)
        {
            throw new ArgumentNullException(
                nameof(httpClientFactory),
                $"The http client factory must provide a base address for the client with name '{httpClientName}'"
            );
        }

        _authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
    }

    /// <summary>
    /// Make sure that the client is authenticated, if necessary
    /// </summary>
    private async Task EnsureAuthentication()
    {
        if (_authenticator.UseAuthentication())
        {
            var token = await _authenticator.Authenticate(_httpClient);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token
            );
        }
    }

    /// <summary>
    /// tests if wanna.bee backend is available
    /// </summary>
    /// <remarks>
    /// Note that this does _not_ check if you're authenticated.
    /// The method will probably throw an <see cref="HttpRequestException"/> if the host cannot be found.
    /// </remarks>
    /// <returns>
    /// Returns true iff the wanna.bee backend function is available under the configured base address.
    /// </returns>
    public async Task<bool> IsAvailable()
    {
        _ = await GetVersion();
        return true;
    }

    /// <summary>
    /// Get information about the build/commit etc.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<Version> GetVersion()
    {
        var uriBuilder = new UriBuilder(_httpClient!.BaseAddress!) { Path = "/version" };
        var response = await _httpClient.GetAsync(uriBuilder.Uri);
        // note that this is available without any authentication
        // see e.g. https://ahbicht.azurewebsites.net/ or https://localhost:7071
        response.EnsureSuccessStatusCode();
        var version = await response.Content.ReadFromJsonAsync<Version>();
        if (version == null)
        {
            throw new HttpRequestException("Could not parse version response");
        }
        return version;
    }

    public async Task<ValidationResponse> Validate(ValidateEdifactRequest request)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Edifact))
        {
            throw new ArgumentException(
                $"Edifact must not be empty but was {(request.Edifact is null ? "<null>" : "'" + request.Edifact + "'")}",
                nameof(request.Edifact)
            );
        }

        var uriBuilder = new UriBuilder(_httpClient!.BaseAddress!) { Path = "/api/v1/validate/" };

        var convertUrl = uriBuilder.Uri.AbsoluteUri;
        await EnsureAuthentication();
        var requestJson = JsonSerializer.Serialize(request);
        var httpResponse = await _httpClient.PostAsync(
            convertUrl,
            new StringContent(
                requestJson,
                Encoding.UTF8,
                System.Net.Mime.MediaTypeNames.Application.Json
            )
        );
        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.Unauthorized when !_authenticator.UseAuthentication():
                    throw new AuthenticationException(
                        $"Did you correctly set up the {nameof(IWannaBeeAuthenticator)}?"
                    );
                default:
                    throw new HttpRequestException(
                        $"Could not parse and evaluate edifact; Status code: {httpResponse.StatusCode} / {responseContent}"
                    );
            }
        }
        var trueFalseResponse = JsonSerializer.Deserialize<TrueFalseValid>(responseContent);
        ValidationResponse? validationResponse; /*  JsonSerializer.Deserialize<ValidationResponse>(
            responseContent,
            _jsonSerializerOptions
        );**/
        if (trueFalseResponse!.Valid)
        {
            validationResponse = JsonSerializer.Deserialize<PositiveValidationResponse>(
                responseContent
            );
        }
        else
        {
            validationResponse = JsonSerializer.Deserialize<NegativeValidationResponse>(
                responseContent
            );
        }

        if (validationResponse is null)
        {
            throw new JsonException(
                $"Could not parse and evaluate response; Status code: {httpResponse.StatusCode} / {responseContent}"
            );
        }
        return validationResponse!;
    }
}
