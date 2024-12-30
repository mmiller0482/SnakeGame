using AsciiGraphics;

namespace SnakeGame.Test.RawGraphics;

public class Coordinate2DFactoryTest
{
    [Theory]
    [InlineData(0,0,0,0)]
    [InlineData(-1,0,1,0)]
    [InlineData(0,-1,0,1)]
    public void TestWrapCoordinate_2By2(int origX, int origY, int expectX, int expectY)
    {
        Coordinate2D origin = new(origX, origY);
        Coordinate2D expect = new(expectX, expectY);

        Coordinate2D res = Coordinate2DFactory.WrapCoordinate(origin, 2, 2);
        
        Assert.Equal(expect, res);
    }
    [Theory]
    [InlineData(-4, 2, 0)]
    [InlineData(-3, 2, 1)]
    [InlineData(-2, 2, 0)]
    [InlineData(-1, 2, 1)]
    [InlineData(0, 2, 0)]
    [InlineData(1, 2, 1)]
    [InlineData(2, 2, 0)]
    [InlineData(3, 2, 1)]
    [InlineData(4, 2, 0)]
    public void TestMyModulo(int left, int right, int expectedResult)
    {
        Assert.Equal(expectedResult, Coordinate2DFactory.ComputeWrappedInteger(left, right));
    }
}