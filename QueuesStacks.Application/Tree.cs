namespace QueuesStacks.Application;

public class TreeNode<T>
{
    public T Data { get; }
    public List<TreeNode<T>> Children { get; }

    public TreeNode(T data)
    {
        Data = data;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }

    public void RemoveChild(TreeNode<T> child)
    {
        Children.Remove(child);
    }
}

public class Tree<T>
{
    public TreeNode<T> Root { get; set; }

    public Tree(T rootData)
    {
        Root = new TreeNode<T>(rootData);
    }

    public void PreOrderTraversal(TreeNode<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        action(node.Data);

        foreach (var child in node.Children)
        {
            PreOrderTraversal(child, action);
        }
    }

    public void PostOrderTraversal(TreeNode<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        foreach (var child in node.Children)
        {
            PostOrderTraversal(child, action);
        }

        action(node.Data);
    }

    public void BreadthFirstTraversal(Action<T> action)
    {
        if (Root == null)
        {
            return;
        }

        Queue<TreeNode<T>> queue = new();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            TreeNode<T> current = queue.Dequeue();
            action(current.Data);

            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
}