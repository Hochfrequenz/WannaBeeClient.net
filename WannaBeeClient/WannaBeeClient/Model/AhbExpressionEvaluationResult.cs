namespace WannaBeeClient.Model;

/// <summary>
/// A class for the result of an ahb expression evaluation
/// </summary>
public class AhbExpressionEvaluationResult
{
    /// <summary>
    /// <see cref="FormatConstraintEvaluationResult"/>
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("format_constraint_evaluation_result")]
    public required FormatConstraintEvaluationResult FormatConstraintEvaluationResult { get; set; }

    /// <summary>
    /// <see cref="RequirementConstraintEvaluationResult"/>
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("requirement_constraint_evaluation_result")]
    public required RequirementConstraintEvaluationResult RequirementConstraintEvaluationResult { get; set; }

    /// <summary>
    /// <see cref="RequirementIndicator"/>
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("requirement_indicator")]
    public RequirementIndicator RequirementIndicator { get; set; }
}
