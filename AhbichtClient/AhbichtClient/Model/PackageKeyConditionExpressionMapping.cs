namespace AhbichtClient.Model;

using EDILibrary;

/// <summary>
/// Maps a package key from a specified EDIFACT format onto a (not yet parsed) condition expression as it is found in
/// the AHB.
/// </summary>
public class PackageKeyConditionExpressionMapping
{
    /// <summary>
    /// The format in which the package is used; e.g. 'UTILMD'.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("edifact_format")]
    public required EdifactFormat EdifactFormat { get; set; }

    /// <summary>
    /// The key of the package without square brackets but with trailing P; e.g. '10P'.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("package_key")]
    public required string PackageKey { get; set; }

    /// <summary>
    /// The expression for which the package is a shortcut; None if unknown e.g. '[20] ∧ [244]'.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("package_expression")]
    public required string PackageExpression { get; set; }
}
