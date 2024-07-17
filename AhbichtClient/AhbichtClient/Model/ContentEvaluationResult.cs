using System.Text.Json.Serialization;

namespace AhbichtClient.Model;

/// <summary>
/// A class that holds the results of a full content evaluation (meaning all hints, requirement constraints and
/// format constraints have been evaluated).
/// </summary>
public class ContentEvaluationResult
{
    /// <summary>
    /// Maps the key of a hint (e.g. "501") to a hint text.
    /// </summary>
    [JsonPropertyName("hints")]
    public required Dictionary<string, string?> Hints { get; set; }

    /// <summary>
    /// Maps the key of a format constraint to the respective evaluation result.
    /// </summary>
    [JsonPropertyName("format_constraints")]
    public required Dictionary<string, EvaluatedFormatConstraint> FormatConstraints { get; set; }

    /// <summary>
    /// Maps the key of a requirement constraint to the respective evaluation result.
    /// </summary>
    [JsonPropertyName("requirement_constraints")]
    public required Dictionary<string, ConditionFulfilledValue> RequirementConstraints { get; set; }

    /// <summary>
    /// Maps the key of a package (e.g. '123') to the respective expression (e.g. '[1] U ([2] O [3])').
    /// </summary>
    [JsonPropertyName("packages")]
    public Dictionary<string, string>? Packages { get; set; }

    /// <summary>
    /// Optional GUID.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }
}
