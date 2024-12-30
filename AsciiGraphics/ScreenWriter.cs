namespace AsciiGraphics;

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
        // Create the normalized content with spaces
        var normalizedContent = string.Join(" ", line);

        // Add borders to the normalized content
        var borderedLine = $"|{normalizedContent}|";

        // Write the bordered line to the console
        Console.WriteLine(borderedLine);
    }
    public static void Clear()
    {
        Console.Clear();
    }
}