using System.Text.Json.Serialization;

namespace WannaBeeClient.Model;

public record Version(
    [property: JsonPropertyName("version")] string VersionNumber,
    [property: JsonPropertyName("buildDate")] string BuildDate,
    [property: JsonPropertyName("commitHash")] string CommitHash,
    [property: JsonPropertyName("commitDate")] string CommitDate,
    [property: JsonPropertyName("buildBranch")] string BuildBranch,
    [property: JsonPropertyName("submoduleCommitHash")] string SubmoduleCommitHash
);
