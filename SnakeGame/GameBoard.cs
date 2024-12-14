using SnakeGame.RawGraphics;

namespace SnakeGame;

public class GameBoard
{
    private readonly List<Sprite> _sprites = new();
    private readonly Grid _grid;
    private readonly bool _wrapAround;

    public GameBoard(Grid grid, bool wrapAround = false)
    {
        _grid = grid;
        _wrapAround = wrapAround;
    }

    public void AddSprite(Sprite sprite)
    {
        if (_wrapAround)
        {
            sprite = new Sprite(
                Coordinate2DUtils.WrapCoordinate(sprite.Position, _grid.XSize, _grid.YSize),
                sprite.Symbol);
        }
        _sprites.Add(sprite);
    }

    public void Render()
    {
        foreach (Sprite sprite in _sprites)
        {
            _grid.SetCell(sprite.Position, sprite.Symbol);
        }
    }

    public void Clear()
    {
        foreach (Sprite sprite in _sprites)
        {
            _grid.ResetCell(sprite.Position);
        }
        
        _sprites.Clear();
    }
}