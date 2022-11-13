using Xunit;

namespace CountingSorting.Tests;

public class CountingSoringTests
{
    [Theory]
    [InlineData(new int[] { 3, 23, 5, 77, 1 }, new int[] { 1, 3, 5, 23, 77 })]
    [InlineData(new int[] { 12, 6, 32, 68, 53 }, new int[] { 6, 12, 32, 53, 68 })]
    public void SortingTests(int[] arr, int[] expected)
    {
        var res = Sort.CountingSort(arr);

        Assert.Equal(expected, arr);
    }
}