namespace QueuesStacks.Application;

public class Graph
{
    private readonly int V;
    private readonly List<int>[] adjacencyList;

    public Graph(int vertices)
    {
        V = vertices;
        adjacencyList = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u);
    }

    public void DFSStart(int startVertex, Action<int> action)
    {
        bool[] visited = new bool[V];
        DFS(startVertex, visited, action);
    }

    private void DFS(int vertex, bool[] visited, Action<int> action)
    {
        visited[vertex] = true;
        action(vertex);

        foreach (var neighbor in adjacencyList[vertex])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, visited, action);
            }
        }
    }

    public void BFS(int startVertex, Action<int> action)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count != 0)
        {
            int vertex = queue.Dequeue();
            action(vertex);

            foreach (var neighbor in adjacencyList[vertex])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}