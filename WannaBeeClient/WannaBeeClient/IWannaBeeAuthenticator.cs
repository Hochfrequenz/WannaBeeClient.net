namespace WannaBeeClient;

/// <summary>
/// Can provide information on whether you need to authenticate against transformer.bee and how
/// </summary>
public interface IWannaBeeAuthenticator
{
    /// <summary>
    /// returns true iff the client should use authentication
    /// </summary>
    /// <returns></returns>
    public bool UseAuthentication();

    /// <summary>
    /// provides the token to authenticate against transformer.bee (if and only if <see cref="UseAuthentication"/> is true)
    /// </summary>
    /// <returns></returns>
    public Task<string> Authenticate(HttpClient client);
}
