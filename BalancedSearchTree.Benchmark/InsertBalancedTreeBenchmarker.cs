using BenchmarkDotNet.Attributes;

namespace BalancedSearchTree.Benchmark;

[MemoryDiagnoser]
[HtmlExporter]
public class InsertBalancedTreeBenchmarker
{
    private BalancedTree<int>? _tree;
    private Random _rand = new();

    private const int InsertsCount = 1000;

    [Params(5000, 10000, 50000, 100000, 200000, 500000)]
    public int N;

    [IterationSetup]
    public void Setup()
    {
        _tree = new();
        for (int i = 0; i < N; i++)
            _tree.Insert(_rand.Next());
    }

    [Benchmark]
    public void Insert()
    {
        for (int i = 0; i < InsertsCount; i++)
            _tree!.Insert(_rand.Next());
    }
}