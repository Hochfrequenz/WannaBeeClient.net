using System.Runtime.Serialization;

namespace AhbichtClient.Model;

/// <summary>
///  Operator which does not function to combine conditions, but as requirement indicator.
/// It stands alone or in front of a condition expression. Please find detailed descriptions of the operators and their usage in the "Allgemeine Festlegungen".
/// Note that with MaKo2022 introduced 2022-04-01 the "O" and "U" prefix operators will be deprecated.
/// Refer to the "Allgemeine Festlegungen" valid up to 2022-04-01 for deprecated "O" and "U".
/// </summary>
public enum PrefixOperator
{
    /// <summary>
    /// The "X" operator. See "Allgemeine Festlegungen" Kapitel 6.8.1. Usually this just means something is required
    /// or required under circumstances defined in a trailing condition expression.
    /// It shall be read as "exclusive or" regarding how qualifiers/codes shall be used from a finite set.
    /// Note that "X" can also be used as "logical exclusive or" (aka "xor") operator in condition expressions.
    /// The prefix operator works differently from the logical operator in condition expressions!
    /// The usage of "X" as logical operator is deprecated since 2022-04-01. It will be replaced with the "⊻" symbol.
    /// </summary>
    [EnumMember(Value = "X")] X,

    /// <summary>
    /// The "O" operator means that at least one out of multiple possible qualifiers/codes has to be given.
    /// This is typically found when describing ways to contact a market partner (CTA): You can use email or phone or fax
    /// but you have to provide at least one of the given possibilities.
    /// The usage of "O" as a prefix operator is deprecated since 2022-04-01.
    /// Note that "O" can also be used as a "logical or" (aka "lor") operator in condition expressions.
    /// The prefix operator works differently from the logical operator in condition expressions!
    /// The usage of "O" as logical operator is also deprecated since 2022-04-01. It will be replaced with the "∨" symbol.
    /// </summary>
    [EnumMember(Value = "O")] O,

    /// <summary>
    /// The "U" operator means that all provided qualifiers/codes have to be used.
    /// The usage of "U" as a prefix operator is deprecated since 2022-04-01.
    /// Note that "U" can also be used as a "logical and" (aka "land") operator in condition expressions.
    /// The prefix operator works differently from the logical operator in condition expressions!
    /// The usage of "U" as logical operator is also deprecated since 2022-04-01. It will be replaced with the "∧" symbol.
    /// </summary>
    [EnumMember(Value = "U")] U
}