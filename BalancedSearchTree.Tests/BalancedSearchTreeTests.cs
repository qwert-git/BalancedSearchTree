using Xunit;
using FluentAssertions;

namespace BalancedSearchTree.Tests;

public partial class BalancedSearchTreeTests
{
    [Fact]
    public void CreateEmptyTree()
    {
        var tree = new BalancedTree<int>();

        tree.Root.Should().BeNull(); ;
    }

    [Theory]
    [InlineData(1)]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    public void ConstructorWithTheRootValue(int rootValue)
    {
        var tree = new BalancedTree<int>(rootValue);

        tree.Root!.Value.Should().Be(rootValue);
    }

    [Theory]
    [InlineData(new int[] { 0 }, 1)]
    [InlineData(new int[] { 0, -100, 100 }, 2)]
    [InlineData(new int[] { 0, -100, 100, 200, 50 }, 3)]
    public void HeightOfRootIsAsExpected(int[] allValues, int expectedHeight)
    {
        var tree = new BalancedTree<int>();
        FillTree(allValues, tree);

        tree.Root!.Height.Should().Be(expectedHeight);
    }

    [Theory]
    [InlineData(new int[] { 1, 1 }, 1)]
    [InlineData(new int[] { 1, 2, 2, 2 }, 2)]
    public void HandleDuplicates(int[] allValues, int expectedHeight)
    {
        var tree = new BalancedTree<int>();
        FillTree(allValues, tree);

        tree.Root!.Height.Should().Be(expectedHeight);
    }

    private static void FillTree(int[] allValues, BalancedTree<int> tree)
    {
        foreach (var value in allValues)
            tree.Insert(value);
    }
}