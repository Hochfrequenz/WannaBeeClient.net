namespace AhbichtClient.Model;

/// <summary>
/// raised when a categorized key extract cannot be created (most likely because of malformed input)
/// </summary>
public class CategorizedKeyExtractError : ArgumentException
{
    public string Expression { get; private set; }

    public CategorizedKeyExtractError(string expression, string? message = null)
        : base(message)
    {
        Expression = expression;
    }
}
