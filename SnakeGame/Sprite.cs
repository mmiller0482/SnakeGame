using SnakeGame.RawGraphics;

namespace SnakeGame;

public class Sprite
{
    public Coordinate2D Position { get; }
    public char Symbol { get; }

    public Sprite(Coordinate2D position, char symbol)
    {
        Position = position;
        Symbol = symbol;
    }
}