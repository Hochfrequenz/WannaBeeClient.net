namespace AhbichtClient.Model;

/// <summary>
/// raised when a package is unresolvable
/// </summary>
public class PackageNotResolvableException : ArgumentException
{
    public string PackageKey { get; private set; }

    public PackageNotResolvableException(string packageKey, string? message = null)
        : base(message)
    {
        PackageKey = packageKey;
    }
}
