namespace QueuesStacks.Application;

public class BinaryTreeNode<T>
{
    public T Data { get; }
    public BinaryTreeNode<T>? Left { get; set; }
    public BinaryTreeNode<T>? Right { get; set; }

    public BinaryTreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

public class BinaryTree<T>
{
    public BinaryTreeNode<T>? Root { get; set; }

    public BinaryTree()
    {
        Root = null;
    }

    public BinaryTree(T rootValue)
    {
        Root = new BinaryTreeNode<T>(rootValue);
    }

    public void PreOrderTraversal(BinaryTreeNode<T>? node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        action(node.Data);
        PreOrderTraversal(node.Left, action);
        PreOrderTraversal(node.Right, action);
    }

    public void InOrderTraversal(BinaryTreeNode<T>? node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.Left, action);
        action(node.Data);
        InOrderTraversal(node.Right, action);
    }

    public void PostOrderTraversal(BinaryTreeNode<T>? node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        PostOrderTraversal(node.Left, action);
        PostOrderTraversal(node.Right, action);
        action(node.Data);
    }

    public void BreadthFirstTraversal(Action<T> action)
    {
        if (Root == null)
        {
            return;
        }

        Queue<BinaryTreeNode<T>> queue = new();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            BinaryTreeNode<T> current = queue.Dequeue();
            action(current.Data);

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }
}