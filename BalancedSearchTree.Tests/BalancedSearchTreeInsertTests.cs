using FluentAssertions;
using Xunit;

namespace BalancedSearchTree.Tests;

public partial class BalancedSearchTreeTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    public void InsertValueToTheEmptyTree(int nodeValue)
    {
        var tree = new BalancedTree<int>();

        tree.Insert(nodeValue);

        tree.Root!.Value.Should().Be(nodeValue);
    }

    [Theory]
    [InlineData(int.MaxValue, 100)]
    [InlineData(int.MaxValue, int.MaxValue - 1)]
    public void AddValueLowerThanRoot(int rootValue, int childValue)
    {
        var tree = new BalancedTree<int>(rootValue);

        tree.Insert(childValue);

        tree.Root!.LeftChild!.Value.Should().Be(childValue);
    }

    [Theory]
    [InlineData(int.MinValue, 100)]
    [InlineData(int.MinValue, int.MinValue + 1)]
    public void AddValueBiggerThanRoot(int rootValue, int childValue)
    {
        var tree = new BalancedTree<int>(rootValue);

        tree.Insert(childValue);

        tree.Root!.RightChild!.Value.Should().Be(childValue);
    }

    [Theory]
    [InlineData(new int[] { 0, -100, 100, -200, -50 }, 50)]
    [InlineData(new int[] { 0, -100, 100, 200, 50 }, -50)]
    [InlineData(new int[] { 0, -100, 100, 50, 200 }, -200)]
    public void InsertNewNode(int[] allValues, int insertValue)
    {
        var tree = new BalancedTree<int>();
        FillTree(allValues, tree);

        tree.Search(insertValue).Should().BeNull();
        
        tree.Insert(insertValue);

        tree.Search(insertValue)!.Value.Should().Be(insertValue);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 4 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4)]
    public void TreeRebalanceAfterInsertingNode(int[] allValues, int expectedRootValue)
    {
        var tree = new BalancedTree<int>();
        FillTree(allValues, tree);

        tree.Root!.Value.Should().Be(expectedRootValue);
    }
}