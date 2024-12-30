namespace AsciiGraphics;

public sealed class Coordinate2D(int x, int y): IEquatable<Coordinate2D>
{
    public int X { get; } = x;
    public int Y { get; } = y;
    
    public override string ToString() => $"({X}, {Y})";

    public bool Equals(Coordinate2D? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Coordinate2D)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}