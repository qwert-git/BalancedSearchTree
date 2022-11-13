namespace BalancedSearchTree;

public record BalancedTreeNode<T>
{
    public T Value { get; }

    public int Height { get; set; }

    public BalancedTreeNode<T>? LeftChild { get; internal set; }
    public BalancedTreeNode<T>? RightChild { get; internal set; }

    public BalancedTreeNode(T value)
    {
        Value = value;
        Height = 1;
    }
}