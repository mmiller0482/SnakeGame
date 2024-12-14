namespace SnakeGame.RawGraphics;

public static class Coordinate2DUtils
{
    // TODO: Make these extension methods on Coordinate2D
    public static Coordinate2D WrapCoordinate(Coordinate2D coordinate, int xMax, int yMax)
    {
        int newX = ComputeWrappedInteger(coordinate.X, xMax);
        int newY = ComputeWrappedInteger(coordinate.Y, yMax);
        return new Coordinate2D(newX, newY);
    }
    public static int ComputeWrappedInteger(int val, int max)
    {
        int result = val % max;
        if (result < 0)
        {
            result += max;
        }

        return result;
    }
}