using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

[JsonConverter(typeof(JsonStringEnumConverter<MigStatus>))]
public enum MigStatus
{
    [JsonStringEnumMemberName("M")]
    M,

    [JsonStringEnumMemberName("C")]
    C,

    [JsonStringEnumMemberName("R")]
    R,

    [JsonStringEnumMemberName("N")]
    N,

    [JsonStringEnumMemberName("D")]
    D,

    [JsonStringEnumMemberName("O")]
    O,
}
