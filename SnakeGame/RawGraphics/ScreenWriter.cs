namespace SnakeGame.RawGraphics;

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


    public static void WriteNormalLine(char[] line)
    {
        char[] normalLine = new char[line.Length*2];
        for (int i = 0; i < line.Length; i++)
        {
            normalLine[i*2] = line[i];
            normalLine[i*2+1] = ' ';
        }
        Console.WriteLine(normalLine);
    }
    public static void Clear()
    {
        Console.Clear();
    }
}