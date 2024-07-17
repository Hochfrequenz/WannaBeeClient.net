using EDILibrary;

namespace AhbichtClient.Model;

/// <summary>
/// Maps a condition from a specified EDIFACT format onto a text as it is found in the AHB.
/// </summary>
public class ConditionKeyConditionTextMapping
{
    /// <summary>
    /// The format in which the condition is used; e.g. 'UTILMD'.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("edifact_format")]
    public required EdifactFormat EdifactFormat { get; set; }

/// <summary>
/// The key of the condition without square brackets; e.g. '78'.
/// </summary>
[System.Text.Json.Serialization.JsonPropertyName("condition_key")]
public required string ConditionKey { get; set; }

/// <summary>
/// The description of the condition as in the AHB; None if unknown;
/// e.g. 'Wenn SG4 STS+7++E02 (Transaktionsgrund: Einzug/Neuanlage)  nicht vorhanden'.
/// </summary>
[System.Text.Json.Serialization.JsonPropertyName("condition_text")]
public required string ConditionText { get; set; }
}
