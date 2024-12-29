namespace SnakeGame.RawGraphics;

// TODO: Extract an Interface out of this.
public class Coordinate2DFactory
{
    public readonly int XMax;
    public readonly int YMax;
    private readonly Random _random;

    public Coordinate2DFactory(int xMax, int yMax)
    {
        XMax = xMax;
        YMax = yMax;
        _random = new Random();
    }


    public Coordinate2D CreateRandom() => CreateRandom([]);
    
    public Coordinate2D CreateRandom(IEnumerable<Coordinate2D> unavailableCoordinates)
    {
        HashSet<Coordinate2D> unavailableSet = new HashSet<Coordinate2D>(unavailableCoordinates);
        Coordinate2D newCoordinate;
        do
        {
            int x = _random.Next(0, XMax);
            int y = _random.Next(0, YMax);
            newCoordinate = Create(x,y);
        } while (unavailableSet.Contains(newCoordinate));
        
        return newCoordinate;
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