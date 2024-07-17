namespace AhbichtClient.Model;
/// <summary>
/// A class for the result of the requirement constraint evaluation.
/// </summary>
public class RequirementConstraintEvaluationResult
{
    /// <summary>
    /// 
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("format_constraints_expression")]
    public string? FormatConstraintsExpression { get; set; }

    /// <summary>
    /// Hint text that should be displayed in the frontend, e.g. "[501] Hinweis: 'ID der Messlokation'"
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("hints")]
    public string? Hints { get; set; }

    /// <summary>
    /// true if condition expression in regard to requirement constraints evaluates to true
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("requirement_constraints_fulfilled")]
    public bool RequirementConstraintsFulfilled { get; set; }

    /// <summary>
    /// true if it is dependent on requirement constraints; None if there are unknown condition nodes left
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("requirement_is_conditional")]
    public bool? RequirementIsConditional { get; set; }
}
