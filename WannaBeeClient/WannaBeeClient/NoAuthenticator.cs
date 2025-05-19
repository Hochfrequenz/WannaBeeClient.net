namespace WannaBeeClient;

/// <summary>
/// a <see cref="IWannaBeeAuthenticator"/> stub that just indicates, we don't need to authenticate against wanna.bee, because we're e.g. in the same network
/// </summary>
public class NoAuthenticator : IWannaBeeAuthenticator
{
    public bool UseAuthentication() => false;

    public Task<string> Authenticate(HttpClient client)
    {
        throw new NotImplementedException(
            "This must never be called, because we don't use authentication."
        );
    }
}
