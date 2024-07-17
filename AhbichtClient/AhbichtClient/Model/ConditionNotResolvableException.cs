namespace AhbichtClient.Model;

/// <summary>
/// raised when a condition is unresolvable
/// </summary>
public class ConditionNotResolvableException : ArgumentException
{
    public string ConditionKey { get; private set; }

    public ConditionNotResolvableException(string conditionKey, string? message = null) : base(message)
    {
        ConditionKey = conditionKey;
    }
}