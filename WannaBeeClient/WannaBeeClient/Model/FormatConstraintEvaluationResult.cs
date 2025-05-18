namespace WannaBeeClient.Model;

/// <summary>
/// A class for the result of the format constraint evaluation.
/// </summary>
public class FormatConstraintEvaluationResult
{
    /// <summary>
    /// All error messages that lead to not fulfilling the format constraint expression
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// true if data entered obey the format constraint expression
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("format_constraints_fulfilled")]
    public bool FormatConstraintsFulfilled { get; set; }
}
