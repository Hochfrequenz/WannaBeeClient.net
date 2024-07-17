namespace AhbichtClient.Model;

/// <summary>
/// A Categorized Key Extract contains those condition keys that are contained inside an expression.
/// For expressions (that do not contain any unresolved package) it's possible to pre-generate all possible outcomes of
/// a content evaluation. CategorizedKeyExtract is also the answer to the question:
/// 'Which information do I need to provide in a ContentEvaluationResult in order to evaluate a given expression?'
/// </summary>
public class CategorizedKeyExtract
{
    /// <summary>
    /// List of keys for which you'll need to provide hint texts in a ContentEvaluationResult.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("hint_keys")]
    public required List<string> HintKeys { get; set; }

    /// <summary>
    /// List of keys for which you'll need to provide EvaluatedFormatConstraints.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("format_constraint_keys")]
    public required List<string> FormatConstraintKeys { get; set; }

    /// <summary>
    /// List of keys for which you'll need to provide ConditionFulfilledValues.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("requirement_constraint_keys")]
    public required List<string> RequirementConstraintKeys { get; set; }

    /// <summary>
    /// List of packages that need to be resolved (additionally).
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("package_keys")]
    public required List<string> PackageKeys { get; set; }

    /// <summary>
    /// A list of time conditions, if present.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("time_condition_keys")]
    public required List<string> TimeConditionKeys { get; set; }
}
