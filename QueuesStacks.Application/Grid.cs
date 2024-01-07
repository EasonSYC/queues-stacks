namespace QueuesStacks.Application;

public class Grid
{
    public static bool IsValidCell(int row, int col, int numRows, int numCols)
    {
        return (row >= 0) && (col >= 0) && (row < numRows) && (col < numCols);
    }

    public static bool DFSStart(int startRow, int startCol, int destRow, int destCol, bool[,] grid)
    {
        int numRows = grid.GetLength(0);
        int numCols = grid.GetLength(1);
        bool[,] visited = new bool[numRows, numCols];

        return DFS(startRow, startCol, destRow, destCol, numRows, numCols, grid, visited);
    }

    private static bool DFS(int row, int col, int destRow, int destCol, int numRows, int numCols, bool[,] grid, bool[,] visited)
    {
        if ((row == destRow) && (col == destCol))
        {
            return true;
        }

        visited[row, col] = true;

        (int dRow, int dCol)[] dPos = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        foreach (var dir in dPos)
        {
            int newRow = row + dir.dRow;
            int newCol = col + dir.dCol;

            if (IsValidCell(newRow, newCol, numRows, numCols) && (grid[newRow, newCol] == false) && !visited[newRow, newCol])
            {
                if (DFS(newRow, newCol, destRow, destCol, numRows, numCols, grid, visited))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool BFS(int startRow, int startCol, int destRow, int destCol, bool[,] grid)
    {
        int numRows = grid.GetLength(0);
        int numCols = grid.GetLength(1);
        bool[,] visited = new bool[numRows, numCols];

        Queue<(int row, int col)> queue = new();
        queue.Enqueue((startRow, startCol));

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();
            int row = cell.row;
            int col = cell.col;

            if ((row == destRow) && (col == destCol))
            {
                return true;
            }

            visited[row, col] = true;

            (int dRow, int dCol)[] dPos = { (-1, 0), (1, 0), (0, -1), (0, 1) };

            foreach (var dir in dPos)
            {
                int newRow = row + dir.dRow;
                int newCol = col + dir.dCol;

                if (IsValidCell(newRow, newCol, numRows, numCols) && (grid[newRow, newCol] == false) && !visited[newRow, newCol])
                {
                    queue.Enqueue((newRow, newCol));
                    visited[newRow, newCol] = true;
                }
            }
        }

        return false;
    }
}