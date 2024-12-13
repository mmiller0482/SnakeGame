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

    public static void Clear()
    {
        Console.Clear();
    }
}