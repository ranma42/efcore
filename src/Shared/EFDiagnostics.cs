// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore;

/// <summary>
///     Contains the IDs of diagnostics emitted by EF Core analyzers, [Experimental] and other mechanisms.
/// </summary>
internal static class EFDiagnostics
{
    public const string InternalUsage = "EF1001";
    public const string InterpolatedStringUsageInRawQueries = "EF1002";
    public const string SuppressUninitializedDbSetRule = "EFSPR1001";

    // Diagnostics for [Experimental]
    public const string ExperimentalApi = "EF9001";
    public const string ProviderExperimentalApi = "EF9002";
    public const string PrecompiledQueryExperimental = "EF9100";
    public const string MetricsExperimental = "EF9101";
    public const string PagingExperimental = "EF9102";

    // These are no longer experimental but keeping the values so we won't re-purpose them
    public const string CosmosVectorSearchExperimental = "EF9103";
    public const string CosmosFullTextSearchExperimental = "EF9104";
}
