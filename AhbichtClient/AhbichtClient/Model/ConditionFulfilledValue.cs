using System.Runtime.Serialization;

namespace AhbichtClient.Model;

/// <summary>
/// Possible values to describe the state of a condition
/// in the condition_fulfilled attribute of the ConditionNodes.
/// </summary>
public enum ConditionFulfilledValue
{
    /// <summary>
    /// If condition is fulfilled
    /// </summary>
    [EnumMember(Value = "FULFILLED")]
    Fulfilled = 1,

    /// <summary>
    /// If condition is not fulfilled
    /// </summary>
    [EnumMember(Value = "UNFULFILLED")]
    Unfulfilled,

    /// <summary>
    /// If it cannot be checked if condition is fulfilled (e.g. "Wenn vorhanden")
    /// </summary>
    [EnumMember(Value = "UNKNOWN")]
    Unknown,

    /// <summary>
    /// A hint or unevaluated format constraint which does not have a status of being fulfilled or not
    /// </summary>
    [EnumMember(Value = "NEUTRAL")]
    Neutral,
}
