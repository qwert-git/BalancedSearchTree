namespace BalancedSearchTree;

public partial class BalancedTree<T> where T : IComparable
{
    public BalancedTreeNode<T>? Root { get; private set; }

    public BalancedTree() { }

    public BalancedTree(T rootValue)
    {
        Root = new BalancedTreeNode<T>(rootValue);
    }

    public void Insert(T nodeValue)
    {
        Root = InsertInternal(Root, nodeValue);
    }

    private static BalancedTreeNode<T>? InsertInternal(BalancedTreeNode<T>? node, T value)
    {
        if (node is null)
            return new BalancedTreeNode<T>(value);
        else if (node.Value.IsBigger(value))
            node.LeftChild = InsertInternal(node.LeftChild, value);
        else if (node.Value.IsLower(value))
            node.RightChild = InsertInternal(node.RightChild, value);
        else
            return node;

        node.Height = CalculateHeight(node);
        int balanceFactor = GetBalanceFactor(node);
        if (balanceFactor > 1) // Left subtree biger
        {
            if (node.LeftChild!.Value.IsBigger(value))
            {
                return RightRotate(node);
            }
            else
            {
                node.LeftChild = LeftRotate(node.LeftChild);
                return RightRotate(node);
            }
        }
        if (balanceFactor < -1) // Right subtree bigger
        {
            if (node.RightChild!.Value.IsLower(value))
            {
                return LeftRotate(node);
            }
            else
            {
                node.RightChild = RightRotate(node.RightChild);
                return LeftRotate(node);
            }
        }


        return node;
    }

    private static BalancedTreeNode<T> RightRotate(BalancedTreeNode<T> node)
    {
        var left = node.LeftChild;
        node.LeftChild = left!.RightChild;
        left.RightChild = node;

        node.Height = CalculateHeight(node);
        left.Height = CalculateHeight(left);

        return left;
    }

    private static BalancedTreeNode<T> LeftRotate(BalancedTreeNode<T> node)
    {
        var right = node.RightChild;
        node.RightChild = right!.LeftChild;
        right.LeftChild = node;

        node.Height = CalculateHeight(node);
        right.Height = CalculateHeight(right);

        return right;
    }

    private static int GetHeightInternal(BalancedTreeNode<T>? node) => node?.Height ?? 0;

    private static int CalculateHeight(BalancedTreeNode<T> node) => 1 + Math.Max(GetHeightInternal(node.LeftChild), GetHeightInternal(node.RightChild));

    private static int GetBalanceFactor(BalancedTreeNode<T>? node)
    {
        if (node is null)
            return 0;
        return GetHeightInternal(node.LeftChild) - GetHeightInternal(node.RightChild);
    }

    public void Remove(T value)
    {
        Root = RemoveInternal(Root, value);
    }

    private BalancedTreeNode<T>? RemoveInternal(BalancedTreeNode<T>? node, T value)
    {
        if (node is null)
            return node;

        if (node.Value.IsBigger(value))
            node.LeftChild = RemoveInternal(node.LeftChild, value);
        else if (node.Value.IsLower(value))
            node.RightChild = RemoveInternal(node.RightChild, value);
        else
        {
            if (node.LeftChild is null)
                return node.RightChild;
            else if (node.RightChild is null)
                return node.LeftChild;

            var minValue = GetMinInternal(node.RightChild);
            RemoveInternal(node.RightChild, value);

            return new BalancedTreeNode<T>(minValue)
            {
                LeftChild = node.LeftChild,
                RightChild = node.RightChild
            };
        }

        // Update the balance factor of each node and balance the tree
        node.Height = CalculateHeight(node);
        int balanceFactor = GetBalanceFactor(node);
        if (balanceFactor > 1)
        {
            if (GetBalanceFactor(node.LeftChild) >= 0)
            {
                return RightRotate(node);
            }
            else
            {
                node.LeftChild = LeftRotate(node.LeftChild!);
                return RightRotate(node);
            }
        }
        if (balanceFactor < -1)
        {
            if (GetBalanceFactor(node.RightChild) <= 0)
            {
                return LeftRotate(node);
            }
            else
            {
                node.RightChild = RightRotate(node.RightChild!);
                return LeftRotate(node);
            }
        }

        return node;
    }

    private T GetMinInternal(BalancedTreeNode<T> node)
    {
        var min = node.Value;
        while (node.LeftChild != null)
        {
            node = node.LeftChild;
            min = node.Value;
        }

        return min;
    }

    public BalancedTreeNode<T>? Search(T value)
    {
        return SearchInternal(Root, value);
    }

    private BalancedTreeNode<T>? SearchInternal(BalancedTreeNode<T>? node, T searchingValue)
    {
        if (node is null)
            return null;

        if (node.Value.EqualsTo(searchingValue))
            return node;
        else if (node.Value.IsBigger(searchingValue))
            return SearchInternal(node.LeftChild, searchingValue);
        else
            return SearchInternal(node.RightChild, searchingValue);
    }
}
