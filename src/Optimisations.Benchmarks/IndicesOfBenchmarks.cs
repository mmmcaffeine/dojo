﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Dgt.Dojo.Optimisations
{
    [MemoryDiagnoser]
    public class IndicesOfBenchmarks
    {
        private const string Value = "var x = Sum(new[] {1, 3, 5, 7});";
        private const string Substring = ", ";

        private static readonly Consumer Consumer = new();
        
        [Benchmark(Baseline = true)]
        public void Baseline() => IndicesOf.Baseline(Value, Substring).Consume(Consumer);

        [Benchmark]
        public void A_YieldReturn() => IndicesOf.A_YieldReturn(Value, Substring).Consume(Consumer);

        [Benchmark]
        public void B_UsingSpanAndList() => IndicesOf.B_UsingSpanAndList(Value, Substring).Consume(Consumer);
        
        [Benchmark]
        public void C_UsingSpanAndStack() => IndicesOf.C_UsingSpanAndStack(Value, Substring).Consume(Consumer);
        
        [Benchmark]
        public void D_ManualComparisonOfSpansUsingRange() => IndicesOf.D_ManualComparisonOfSpansUsingRange(Value, Substring).Consume(Consumer);

        [Benchmark]
        public void E_ManualComparisonOfSpansUsingOffsetAndLocalFunction() =>
            IndicesOf.E_ManualComparisonOfSpansUsingOffsetAndLocalFunction(Value, Substring).Consume(Consumer);
        
        [Benchmark]
        public void F_ManualComparisonOfSpansUsingOffsetAndNestedLoop() =>
            IndicesOf.F_ManualComparisonOfSpansUsingOffsetAndNestedLoop(Value, Substring).Consume(Consumer);
    }
}