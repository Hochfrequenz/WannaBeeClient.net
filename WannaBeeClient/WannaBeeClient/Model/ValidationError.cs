using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")] // <-- this only works if the 'type' value is the FIRST KVP inside the dictionary returned by the API
// if this is not the case, you'll get a System.NotSupportedException: The JSON payload for polymorphic interface or abstract type 'WannaBeeClient.Model.ValidationError' must specify a type discriminator. Path: $.errors[0] | LineNumber: 0 | ...
[JsonDerivedType(typeof(ForbiddenButFilledError), "ForbiddenButFilledError")]
[JsonDerivedType(typeof(FormatConstraintUnfulfilledError), "FormatConstraintUnfulfilledError")]
[JsonDerivedType(typeof(IllegalCodeError), "IllegalCodeError")]
[JsonDerivedType(typeof(IllegalSegmentStructureError), "IllegalSegmentStructureError")]
[JsonDerivedType(typeof(MismatchedType), "MismatchedType")]
[JsonDerivedType(typeof(MissingSegmentError), "MissingSegmentError")]
[JsonDerivedType(typeof(RequiredButMissingError), "RequiredButMissingError")]
[JsonDerivedType(typeof(UnexpectedSegmentError), "UnexpectedSegmentError")]
[JsonDerivedType(typeof(UnknownCodeError), "UnknownCodeError")]
public abstract record ValidationError
{
    [JsonPropertyName("type")]
    public abstract string Type { get; }

    [JsonPropertyName("detail")]
    public abstract string Detail { get; init; }

    [JsonPropertyName("description")]
    public abstract string Description { get; init; }
}
