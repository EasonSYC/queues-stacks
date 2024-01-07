namespace QueuesStacks.Tests;
using System.Text;
using QueuesStacks.Application;

[TestClass]
public class TreeTest
{
    private Tree<int> SampleGeneralTree()
    {
        Tree<int> tree = new(1);
        var root = tree.Root;
        root.AddChild(new(2));
        root.AddChild(new(3));
        root.Children[0].AddChild(new(4));
        root.Children[0].AddChild(new(5));
        root.Children[1].AddChild(new(6));
        return tree;
    }

    [TestMethod]
    public void TestPreOrderTraversal()
    {
        Tree<int> tree = SampleGeneralTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.PreOrderTraversal(tree.Root, action);
        string expected = "1 2 4 5 3 6 ";
        Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestPostOrderTraversal()
    {
        Tree<int> tree = SampleGeneralTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.PostOrderTraversal(tree.Root, action);
        string expected = "4 5 2 6 3 1 ";
        Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestBreadthFirstTraversal()
    {
        Tree<int> tree = SampleGeneralTree();
        StringBuilder result = new StringBuilder();
        Action<int> action = (data) => result.Append(data + " ");
        tree.BreadthFirstTraversal(action);
        string expected = "1 2 3 4 5 6 ";
        Assert.AreEqual(expected, result.ToString());
    }
}

