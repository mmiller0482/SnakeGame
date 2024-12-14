namespace SnakeGame.RawGraphics;

public class Coordinate2D(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    
    public override string ToString() => $"({X}, {Y})";

    public override bool Equals(object? obj)
    {
        return obj is Coordinate2D coordinate2D && X == coordinate2D.X && Y == coordinate2D.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}