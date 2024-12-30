using AsciiGraphics;

namespace SnakeGame.Test.RawGraphics;

public class Coordinate2DTest
{
    [Fact]
    public void AssertCoordinatesAreEqual()
    {
        Coordinate2D c1 = new(0, 1);
        Coordinate2D c2 = new(0, 1);
        Assert.Equal(c1, c2);
    }

    [Fact]
    public void AssertCoordinatesAreNotEqual()
    {
        Coordinate2D c1 = new(0, 1);
        Coordinate2D c2 = new(1, 0);
        Assert.NotEqual(c1, c2);
    }
}