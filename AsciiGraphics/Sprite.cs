namespace AsciiGraphics;

public class Sprite : IPlottable
{
    public Coordinate2D Position { get; }
    public char Symbol { get; }

    public Sprite(Coordinate2D position, char symbol)
    {
        Position = position;
        Symbol = symbol;
    }

    public void Plot(GameBoard gameBoard)
    {
        gameBoard.AddSprite(this);
    }
}