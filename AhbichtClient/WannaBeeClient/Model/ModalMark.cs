using System.Runtime.Serialization;

namespace WannaBeeClient.Model;

/// <summary>
/// A modal mark describes if information are obligatory or not. The German term is "Merkmal".
/// The modal marks are defined by the EDI Energy group (see edi-energy.de → Dokumente → Allgemeine Festlegungen).
/// The modal mark stands alone or before a condition expression.
/// It can be the start of several requirement indicator expressions in one AHB expression.
/// </summary>
public enum ModalMark
{
    /// <summary>
    /// German term for "Must". Is required for the correct structure of the message.
    /// If the following condition is not fulfilled, the information must not be given ("must not")
    /// </summary>
    [EnumMember(Value = "MUSS")]
    Muss,

    /// <summary>
    /// German term for "Should". Is required for technical reasons.
    /// Always followed by a condition.
    /// If the following condition is not fulfilled, the information must not be given.
    /// </summary>
    [EnumMember(Value = "SOLL")]
    Soll,

    /// <summary>
    /// German term for "Can". Optional
    /// </summary>
    [EnumMember(Value = "KANN")]
    Kann,
}
