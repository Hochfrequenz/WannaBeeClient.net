namespace AhbichtClient.Model;

/// <summary>
/// This class is the base class of all evaluated format constraints. They are used in the context of the
/// Mussfeldprüfung after the format constraints are evaluated to see if the format constraint expression is
/// fulfilled or not.
/// </summary>
public class EvaluatedFormatConstraint
{
    /// <summary>
    /// error message if the data does not obey the format constraint expression
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// true if data obey the format constraint expression
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("format_constraint_fulfilled")]
    public required bool FormatConstraintFulfilled { get; set; }
}
