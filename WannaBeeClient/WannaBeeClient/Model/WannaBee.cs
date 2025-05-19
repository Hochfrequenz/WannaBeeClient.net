namespace WannaBeeClient.Model;

using System;
using System.Text.Json.Serialization;

// Root Response Models
public record RootResponse(
    [property: JsonPropertyName("message")] string Message = "Welcome to the wannabee API!"
);

// Version Models
public record Version(
    [property: JsonPropertyName("version")] string VersionNumber,
    [property: JsonPropertyName("buildDate")] string BuildDate,
    [property: JsonPropertyName("commitHash")] string CommitHash,
    [property: JsonPropertyName("commitDate")] string CommitDate,
    [property: JsonPropertyName("buildBranch")] string BuildBranch,
    [property: JsonPropertyName("submoduleCommitHash")] string SubmoduleCommitHash
);

// Validation Request/Response Models
public record ValidateEdifactRequest(
    [property: JsonPropertyName("edifact")] string Edifact,
    [property: JsonPropertyName("include_boneycomb_paths")] bool IncludeBoneycombPaths
);

[JsonPolymorphic(TypeDiscriminatorPropertyName = "valid")]
// [JsonDerivedType(typeof(PositiveValidationResponse), true)] <-- doesn't work yet, we're using a workaround
// [JsonDerivedType(typeof(NegativeValidationResponse), false)]
public abstract record ValidationResponse { };

public record PositiveValidationResponse([property: JsonPropertyName("valid")] bool Valid = true)
    : ValidationResponse { }

public record NegativeValidationResponse(
    [property: JsonPropertyName("errors")] IReadOnlyList<ValidationError> Errors,
    [property: JsonPropertyName("num_errors")] int NumErrors,
    [property: JsonPropertyName("valid")] bool Valid = false
) : ValidationResponse { }

// Error Models
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
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

public record ForbiddenButFilledError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "ForbiddenButFilledError";
}

public record FormatConstraintUnfulfilledError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("format_constraint_error")] string FormatConstraintError,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "FormatConstraintUnfulfilledError";
}

public record IllegalCodeError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "IllegalCodeError";
}

public record IllegalSegmentStructureError(
    [property: JsonPropertyName("ahb_segment")] FundamendSegment AhbSegment,
    [property: JsonPropertyName("mig_segment")] FundamendMigSegment MigSegment,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "IllegalSegmentStructureError";
}

public record MismatchedType(
    [property: JsonPropertyName("found_type")] string FoundType,
    [property: JsonPropertyName("expected_type")] string ExpectedType,
    [property: JsonPropertyName("location_description")] string LocationDescription,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "MismatchedType";
}

public record MissingSegmentError(
    [property: JsonPropertyName("segment")] string Segment,
    [property: JsonPropertyName("index_in_segment_list")] int? IndexInSegmentList,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "MissingSegmentError";
}

public record RequiredButMissingError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("ahb_object")] object AhbObject,
    [property: JsonPropertyName("ahb_object_path")] IReadOnlyList<object> AhbObjectPath,
    [property: JsonPropertyName("ahb_expression")] string AhbExpression,
    [property: JsonPropertyName("ahb_expression_result_json")] string AhbExpressionResultJson,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "RequiredButMissingError";
}

public record UnexpectedSegmentError(
    [property: JsonPropertyName("index_in_segment_list")] int? IndexInSegmentList,
    [property: JsonPropertyName("expected_segments")]
        IReadOnlyList<FundamendMigSegment> ExpectedSegments,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "UnexpectedSegmentError";
}

public record UnknownCodeError(
    [property: JsonPropertyName("path")] IReadOnlyList<object> Path,
    [property: JsonPropertyName("paths_boneycomb")] IReadOnlyList<string>? PathsBoneycomb,
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("detail")] string Detail,
    [property: JsonPropertyName("description")] string Description
) : ValidationError
{
    [JsonPropertyName("type")]
    public override string Type => "UnknownCodeError";
}

// HTTP Validation Error
public record HTTPValidationError(
    [property: JsonPropertyName("detail")] IReadOnlyList<ValidationErrorDetail> Detail
);

public record ValidationErrorDetail(
    [property: JsonPropertyName("loc")] IReadOnlyList<object> Loc,
    [property: JsonPropertyName("msg")] string Msg,
    [property: JsonPropertyName("type")] string Type
);

// Anwendungshandbuch Models
public record Anwendungshandbuch(
    [property: JsonPropertyName("veroeffentlichungsdatum")] DateOnly Veroeffentlichungsdatum,
    [property: JsonPropertyName("autor")] string Autor,
    [property: JsonPropertyName("versionsnummer")] string Versionsnummer,
    [property: JsonPropertyName("anwendungsfaelle")] IReadOnlyList<Anwendungsfall> Anwendungsfaelle,
    [property: JsonPropertyName("bedingungen")] IReadOnlyList<Bedingung> Bedingungen,
    [property: JsonPropertyName("ub_bedingungen")] IReadOnlyList<UbBedingung> UbBedingungen,
    [property: JsonPropertyName("pakete")] IReadOnlyList<Paket> Pakete
);

public record Anwendungsfall(
    [property: JsonPropertyName("pruefidentifikator")] string Pruefidentifikator,
    [property: JsonPropertyName("beschreibung")] string Beschreibung,
    [property: JsonPropertyName("kommunikation_von")] string KommunikationVon,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("elements")] IReadOnlyList<object> Elements
);

public record Bedingung(
    [property: JsonPropertyName("nummer")] string Nummer,
    [property: JsonPropertyName("text")] string Text
);

public record UbBedingung(
    [property: JsonPropertyName("nummer")] string Nummer,
    [property: JsonPropertyName("text")] string Text
);

public record Paket(
    [property: JsonPropertyName("nummer")] string Nummer,
    [property: JsonPropertyName("text")] string Text
);

// Fundamend Models
public record FundamendSegment(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("number")] string Number,
    [property: JsonPropertyName("ahb_status")] string? AhbStatus,
    [property: JsonPropertyName("data_elements")] IReadOnlyList<object> DataElements
);

public record FundamendDataElement(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("ahb_status")] string? AhbStatus,
    [property: JsonPropertyName("codes")] IReadOnlyList<FundamendCode> Codes
);

public record FundamendDataElementGroup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("data_elements")] IReadOnlyList<FundamendDataElement> DataElements
);

public record FundamendCode(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("value")] string? Value,
    [property: JsonPropertyName("ahb_status")] string AhbStatus
);

public record SegmentGroup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("ahb_status")] string? AhbStatus,
    [property: JsonPropertyName("elements")] IReadOnlyList<object> Elements
);

// Fundamend MIG Models
public record FundamendMigSegment(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("counter")] string Counter,
    [property: JsonPropertyName("level")] int Level,
    [property: JsonPropertyName("number")] string Number,
    [property: JsonPropertyName("max_rep_std")] int MaxRepStd,
    [property: JsonPropertyName("max_rep_specification")] int MaxRepSpecification,
    [property: JsonPropertyName("status_std")] MigStatus StatusStd,
    [property: JsonPropertyName("status_specification")] MigStatus StatusSpecification,
    [property: JsonPropertyName("example")] string? Example,
    [property: JsonPropertyName("data_elements")] IReadOnlyList<object> DataElements
);

public record FundamendMigDataElement(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("status_std")] MigStatus StatusStd,
    [property: JsonPropertyName("status_specification")] MigStatus StatusSpecification,
    [property: JsonPropertyName("format_std")] string FormatStd,
    [property: JsonPropertyName("format_specification")] string FormatSpecification,
    [property: JsonPropertyName("codes")] IReadOnlyList<FundamendMigCode> Codes
);

public record FundamendMigDataElementGroup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("status_std")] MigStatus StatusStd,
    [property: JsonPropertyName("status_specification")] MigStatus StatusSpecification,
    [property: JsonPropertyName("data_elements")]
        IReadOnlyList<FundamendMigDataElement> DataElements
);

public record FundamendMigCode(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("value")] string? Value
);

// Enums
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
