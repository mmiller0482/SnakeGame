namespace SnakeGame.RawGraphics;

// TODO: Extract an Interface out of this.
public class Coordinate2DFactory
{
    private readonly int _xMax;
    private readonly int _yMax;

    public Coordinate2DFactory(int xMax, int yMax)
    {
        _xMax = xMax;
        _yMax = yMax;
    }

    public Coordinate2D Create(Coordinate2D coordinate) => Create(coordinate.X, coordinate.Y);
    
    public Coordinate2D Create(int x, int y)
    {
        int newX = ComputeWrappedInteger(x, _xMax);
        int newY = ComputeWrappedInteger(y, _yMax);
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