namespace SnakeGame.RawGraphics;

// TODO: Extract an Interface out of this.
public class Coordinate2DFactory
{
    public readonly int XMax;
    public readonly int YMax;

    public Coordinate2DFactory(int xMax, int yMax)
    {
        XMax = xMax;
        YMax = yMax;
    }

    public Coordinate2D Create(Coordinate2D coordinate) => Create(coordinate.X, coordinate.Y);
    
    public Coordinate2D Create(int x, int y)
    {
        int newX = ComputeWrappedInteger(x, XMax);
        int newY = ComputeWrappedInteger(y, YMax);
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