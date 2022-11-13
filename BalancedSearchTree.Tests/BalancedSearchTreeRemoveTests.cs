using FluentAssertions;
using Xunit;

namespace BalancedSearchTree.Tests;

public partial class BalancedSearchTreeTests
{
    [Theory]
    [InlineData(10)]
    public void RemoveRoot(int rootValue)
    {
        var tree = new BalancedTree<int>(rootValue);

        tree.Remove(rootValue);

        tree.Root.Should().BeNull();
    }

    [Theory]
    [InlineData(new[] { 1, 2, -2 }, -2)]
    [InlineData(new[] { 1, 2, -2 }, 2)]
    [InlineData(new[] { 1, 2, -2, -5 }, -2)]
    [InlineData(new[] { 1, 2, -2, -5, -1 }, -5)]
    public void RemoveNode(int[] values, int removeValue)
    {
        var tree = new BalancedTree<int>();
        FillTree(values, tree);
        
        tree.Remove(removeValue);

        tree.Search(removeValue).Should().BeNull();
    }

    [Theory]
    [InlineData(new[] { 1, 2, -2, -5, -1 }, 2, -2)]
    [InlineData(new[] { 0, 2, -2, 5, 1 }, -2, 2)]
    public void RebalanceAfterRemove(int[] values, int removeValue, int expectedRootValue)
    {
        var tree = new BalancedTree<int>();
        FillTree(values, tree);
        
        tree.Remove(removeValue);

        tree.Search(removeValue).Should().BeNull();
        tree.Root!.Value.Should().Be(expectedRootValue);
    }
}