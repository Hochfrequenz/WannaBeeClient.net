using WannaBeeClient.Model;

namespace WannaBeeClient;

/// <summary>
/// Interface of all the things that can validate edifact messages against the rules defined in the Anwendungshandbuch (AHB)
/// </summary>
/// <remarks>This will be useful if you want to mock the client elsewhere</remarks>
public interface IEdifactAhbValidator
{
    /// <summary>
    /// given an ahb condition expression and information about which conditions is fulfilled, evaluate the expression as whole
    /// </summary>
    public Task<ValidationResponse> Validate(ValidateEdifactRequest request);
}
