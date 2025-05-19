using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "valid")]
// [JsonDerivedType(typeof(PositiveValidationResponse), true)] <-- using booleans as type discriminators doesn't work yet, we're using a workaround (STRG+F record TrueFalseValid)
// [JsonDerivedType(typeof(NegativeValidationResponse), false)]
public abstract record ValidationResponse { };
