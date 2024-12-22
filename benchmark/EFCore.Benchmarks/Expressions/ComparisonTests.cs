// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Microsoft.EntityFrameworkCore.Benchmarks.Expressions;

public class ComparisonTests
{
    [Params(1, 10, 100, 1000)]
    public int LhsSize { get; set; }

    [Params(1, 10, 100, 1000)]
    public int RhsSize { get; set; }

    private SqlExpression _lhs;
    private SqlExpression _rhs;

    private SqlExpression BuildExpr(int size, SqlExpression value)
    {
        var r = value;
        for (var i = 0; i < size; i++)
        {
            // in the comparison the left expression is compared first, so
            // always use the same expression; specifically, we accumulate a
            // chain of expressions (true && (true && (true && ...)))
            r = new SqlBinaryExpression(
                ExpressionType.AndAlso,
                new SqlConstantExpression(true, typeof(bool), null),
                r,
                typeof(bool),
                null);
        }

        return r;
    }

    [GlobalSetup]
    public virtual void Initialize()
    {
        _lhs = BuildExpr(LhsSize, new SqlConstantExpression(true, typeof(bool), null));
        _rhs = BuildExpr(RhsSize, new SqlConstantExpression(false, typeof(bool), null));
    }

    [Benchmark]
    public bool CompareEquals() => _lhs.Equals(_rhs);
}
