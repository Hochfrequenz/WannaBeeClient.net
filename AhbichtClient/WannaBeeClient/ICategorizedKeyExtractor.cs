using WannaBeeClient.Model;

namespace WannaBeeClient;

/// <summary>
/// Interface of all the things that can extract conditions keys from a given expression
/// </summary>
/// <remarks>This will be useful if you want to mock the client elsewhere</remarks>
public interface ICategorizedKeyExtractor
{
    /// <summary>
    /// given an ahb condition expression and information about which conditions is fulfilled, evaluate the expression as whole
    /// </summary>
    public Task<CategorizedKeyExtract> ExtractKeys(string expression);
}
