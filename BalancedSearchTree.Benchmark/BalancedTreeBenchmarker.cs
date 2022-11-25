using BenchmarkDotNet.Attributes;

namespace BalancedSearchTree.Benchmark;

[MemoryDiagnoser]
[HtmlExporter]
public class BalancedTreeBenchmarker
{
    private BalancedTree<int>? _tree;
    private Random _rand = new();

    private const int OperationsCount = 1000;

    [Params(5000, 10000, 50000, 100000, 200000, 300000)]
    public int N;

    [IterationSetup]
    public void Setup()
    {
        _tree = new();
        for (int i = 0; i < N; i++)
            _tree.Insert(_rand.Next());
    }

    [Benchmark]
    public void Search()
    {
        for (int i = 0; i < N; i++)
            _tree!.Search(_rand.Next());
    }

    [Benchmark]
    public void Remove()
    {
        for (int i = 0; i < N; i++)
            _tree!.Insert(_rand.Next());
    }
}