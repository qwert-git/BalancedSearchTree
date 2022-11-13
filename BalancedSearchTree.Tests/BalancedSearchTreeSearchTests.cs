using FluentAssertions;
using Xunit;

namespace BalancedSearchTree.Tests;

public partial class BalancedSearchTreeTests
{
    [Fact]
    public void EmptyTreeReturnNull()
    {
        var tree = new BalancedTree<int>();

        var res = tree.Search(1);

        res.Should().BeNull();
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 0)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 0)]
    public void ValueNotFoundTreeReturnNull(int[] allValues, int searchValue)
    {
        var tree = new BalancedTree<int>();
        FillTree(allValues, tree);

        var res = tree.Search(searchValue);

        res.Should().BeNull();
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 1)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 4)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 5)]
    public void FindValueInTree(int[] allValues, int searchValue)
    {
        var tree = new BalancedTree<int>();
        FillTree(allValues, tree);

        var res = tree.Search(searchValue);

        res.Should().NotBeNull();
        res!.Value.Should().Be(searchValue);
    }
}