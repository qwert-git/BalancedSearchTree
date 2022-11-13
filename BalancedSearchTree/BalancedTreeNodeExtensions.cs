namespace BalancedSearchTree;

public static class BalancedTreeNodeExtensions
{
    public static bool IsBigger<T>(this T first, T second) where T : IComparable
    {
        return first.CompareTo(second) > 0;
    }

    public static bool IsLower<T>(this T first, T second) where T : IComparable
    {
        return first.CompareTo(second) < 0;
    }

    public static bool EqualsTo<T>(this T first, T second) where T : IComparable
    {
        return first.CompareTo(second) == 0;
    }
}