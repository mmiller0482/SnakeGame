namespace SnakeGame;

public static class ScreenWriter
{
    public static void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public static void WriteLine(char[] line)
    {
        Console.WriteLine(line);
    }

    public static void ClearWrite2D(char[,] grid)
    {
        Clear();
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            char[] rowBuffer = new char[grid.GetLength(1)];
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                rowBuffer[col] = grid[row, col];
            }
            WriteLine(rowBuffer);
        }
    }
    public static void Clear()
    {
        Console.Clear();
    }
}