namespace QueuesStacks;
using QueuesStacks.Application;

class Program
{
    static void Main()
    {
        PolishNotationDemonstrate();
        TreeDemonstrate();
        BinaryTreeDemonstrate();
        GraphDemonstrate();
        GridDemonstrate();
        ShuntingYardDemonstrate();
    }

    static void PolishNotationDemonstrate()
    {
        string prefixExpression = "+ 2 * 3 4";
        double prefixResult = PolishNotation.PrefixNotation(prefixExpression);
        Console.WriteLine("Result: " + prefixResult);

        string postfixExpression = "2 3 4 * +";
        double postfixResult = PolishNotation.PostfixNotation(postfixExpression);
        Console.WriteLine("Result: " + postfixResult);
    }

    static void TreeDemonstrate()
    {
        Tree<int> tree = new(1);
        var root = tree.Root;
        root.AddChild(new(2));
        root.AddChild(new(3));
        root.Children[0].AddChild(new(4));
        root.Children[0].AddChild(new(5));
        root.Children[1].AddChild(new(6));

        Console.WriteLine("Pre-order Traversal:");
        tree.PreOrderTraversal(tree.Root, data => Console.Write(data + " "));
        Console.WriteLine();

        Console.WriteLine("Post-order Traversal:");
        tree.PostOrderTraversal(tree.Root, data => Console.Write(data + " "));
        Console.WriteLine();

        Console.WriteLine("Breadth-first Traversal:");
        tree.BreadthFirstTraversal(data => Console.Write(data + " "));
        Console.WriteLine();
    }

    static void BinaryTreeDemonstrate()
    {
        BinaryTree<int> tree = new(1);
        var root = tree.Root;
        root!.Left = new(2);
        root.Right = new(3);
        root.Left.Left = new(4);
        root.Left.Right = new(5);
        root.Right.Left = new(6);

        Console.WriteLine("Pre-order Traversal:");
        tree.PreOrderTraversal(tree.Root, data => Console.Write(data + " "));
        Console.WriteLine();

        Console.WriteLine("In-order Traversal:");
        tree.InOrderTraversal(tree.Root, data => Console.Write(data + " "));
        Console.WriteLine();

        Console.WriteLine("Post-order Traversal:");
        tree.PostOrderTraversal(tree.Root, data => Console.Write(data + " "));
        Console.WriteLine();

        Console.WriteLine("Breadth-first Traversal:");
        tree.BreadthFirstTraversal(data => Console.Write(data + " "));
        Console.WriteLine();
    }

    static void GraphDemonstrate()
    {
        Graph graph = new(7);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 6);

        Console.WriteLine("DFS Traversal:");
        graph.DFSStart(0, vertex => Console.WriteLine(vertex + " "));
        Console.WriteLine();

        Console.WriteLine("BFS Traversal:");
        graph.BFS(0, vertex => Console.WriteLine(vertex + " "));
        Console.WriteLine();
    }

    static void GridDemonstrate()
    {
        bool[,] grid = 
        {
            { false,  true, false, false },
            { false, false,  true, false },
            { false,  true, false, false },
            { false, false, false, false }
        };

        bool canReachDestinationDFS = Grid.DFSStart(0, 0, 3, 3, grid);
        bool canReachDestinationBFS = Grid.BFS(0, 0, 3, 3, grid);

        Console.WriteLine("DFS: " + (canReachDestinationDFS ? "Can reach the destination" : "Cannot reach the destination"));
        Console.WriteLine("BFS: " + (canReachDestinationBFS ? "Can reach the destination" : "Cannot reach the destination"));
    }

    static void ShuntingYardDemonstrate()
    {
        string? s;
        do
        {
            s = Console.ReadLine();
            Console.WriteLine(ShuntingYard.EvaluateExpression(s!));
        } while (!string.IsNullOrWhiteSpace(s));
    }
}