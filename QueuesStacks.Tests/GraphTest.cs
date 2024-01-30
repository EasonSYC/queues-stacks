namespace QueuesStacks.Tests;
using System.Text;
using QueuesStacks.Application;

[TestClass]
public class GraphTests
{
    private Graph SampleGraph()
    {
        Graph graph = new(7);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 6);
        return graph;
    }

    [TestMethod]
    public void TestDFS()
    {
        Graph graph = SampleGraph();
        StringBuilder result = new();
        graph.DFSStart(0, vertex => result.Append(vertex + " "));
        string expected = "0 1 3 4 2 5 6 ";
        Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestBFS()
    {
        Graph graph = SampleGraph();
        StringBuilder result = new();
        graph.BFS(0, vertex => result.Append(vertex + " "));
        string expected = "0 1 2 3 4 5 6 ";
        Assert.AreEqual(expected, result.ToString());
    }
}