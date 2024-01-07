namespace QueuesStacks.Tests;
using QueuesStacks.Application;

[TestClass]
public class GridTest
{
    [TestMethod]
    public void TestDFSTraverse()
    {
        bool[,] grid = 
        {
            { false,  true, false, false },
            { false, false,  true, false },
            { false,  true, false, false },
            { false, false, false, false }
        };

        bool canReachDestination = Grid.DFSStart(0, 0, 3, 3, grid);

        Assert.IsTrue(canReachDestination);
    }

    [TestMethod]
    public void TestDFSTraverseNoPath()
    {
        bool[,] grid =
        {
            { false,  true, false, false },
            { false,  true,  true, false },
            { false,  true, false, false },
            {  true, false, false, false }
        };

        bool canReachDestination = Grid.DFSStart(0, 0, 3, 3, grid);

        Assert.IsFalse(canReachDestination);
    }

    [TestMethod]
    public void TestBFSTraverse()
    {
        bool[,] grid =
        {
            { false,  true, false, false },
            { false, false,  true, false },
            { false,  true, false, false },
            { false, false, false, false }
        };

        bool canReachDestination = Grid.BFS(0, 0, 3, 3, grid);

        Assert.IsTrue(canReachDestination);
    }

    [TestMethod]
    public void TestBFSTraverseNoPath()
    {
        bool[,] grid =
        {
            { false,  true, false, false },
            { false,  true,  true, false },
            { false,  true, false, false },
            {  true, false, false, false }
        }
        ;
        bool canReachDestination = Grid.BFS(0, 0, 3, 3, grid);

        Assert.IsFalse(canReachDestination);
    }
}

