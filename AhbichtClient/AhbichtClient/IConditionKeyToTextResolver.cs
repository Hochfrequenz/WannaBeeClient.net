using AhbichtClient.Model;
using EDILibrary;

namespace AhbichtClient;

/// <summary>
/// Interface of all the things that can map a condition key to a human-readable text
/// </summary>
/// <remarks>This will be useful if you want to mock the client elsewhere</remarks>
public interface IConditionKeyToTextResolver
{
    /// <summary>
    /// given a condition key, returns the text that is associated with it
    /// </summary>
    /// <raises><see cref="ConditionNotResolvableException"/> if the condition key is not resolvable</raises>
    public Task<ConditionKeyConditionTextMapping> ResolveCondition(string conditionKey, EdifactFormat format, EdifactFormatVersion formatVersion);
}