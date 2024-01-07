namespace QueuesStacks.Tests;
using System.Text;
using QueuesStacks.Application;

[TestClass]
public class BinaryTreeTest
{
    private BinaryTree<int> SampleBinaryTree()
    {
        BinaryTree<int> tree = new(1);
        var root = tree.Root;
        root!.Left = new(2);
        root.Right = new(3);
        root.Left.Left = new(4);
        root.Left.Right = new(5);
        root.Right.Left = new(6);
        return tree;
    }

    [TestMethod]
    public void TestPreOrderTraversal()
    {
        BinaryTree<int> tree = SampleBinaryTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.PreOrderTraversal(tree.Root, action);
        string expected = "1 2 4 5 3 6 ";
        Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestInOrderTraversal()
    {
        BinaryTree<int> tree = SampleBinaryTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.InOrderTraversal(tree.Root, action);
        string expected = "4 2 5 1 6 3 ";
        Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestPostOrderTraversal()
    {
        BinaryTree<int> tree = SampleBinaryTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.PostOrderTraversal(tree.Root, action);
        string expected = "4 5 2 6 3 1 ";
        Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestBreadthFirstTraversal()
    {
        BinaryTree<int> tree = SampleBinaryTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.BreadthFirstTraversal(action);
        string expected = "1 2 3 4 5 6 ";
        Assert.AreEqual(expected, result.ToString());
    }
}

