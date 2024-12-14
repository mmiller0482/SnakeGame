using SnakeGame.Graphics;

namespace SnakeGame.Test;

public class ScreenWriterTest
{

    [Fact]
    public void TestWriteLine_String()
    {
        var oldOut = Console.Out;
        StringWriter capturedOut = new StringWriter();
        Console.SetOut(capturedOut);

        string sample = "abc";
        ScreenWriter.WriteLine(sample);
        
        Assert.Contains("abc", capturedOut.ToString());
        
        Console.SetOut(oldOut);
    }
    
    [Fact]
    public void TestWriteLine_CharArray()
    {
        var oldOut = Console.Out;
        StringWriter capturedOut = new StringWriter();
        Console.SetOut(capturedOut);

        char[] sample = ['a', 'b', 'c'];
        ScreenWriter.WriteLine(sample);
        
        Assert.Contains("abc", capturedOut.ToString());
        
        Console.SetOut(oldOut);
    }

}