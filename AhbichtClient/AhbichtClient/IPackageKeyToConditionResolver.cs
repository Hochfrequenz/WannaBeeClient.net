using AhbichtClient.Model;
using EDILibrary;

namespace AhbichtClient;

/// <summary>
/// Interface of all the things that can map a package key to a condition string
/// </summary>
/// <remarks>This will be useful if you want to mock the client elsewhere</remarks>
public interface IPackageKeyToConditionResolver
{
    /// <summary>
    /// given a package key, returns the condition that is associated with it
    /// </summary>
    /// <raises><see cref="PackageNotResolvableException"/> if the package key is not resolvable</raises>
    public Task<PackageKeyConditionExpressionMapping> ResolvePackage(
        string packageKey,
        EdifactFormat format,
        EdifactFormatVersion formatVersion
    );
}
