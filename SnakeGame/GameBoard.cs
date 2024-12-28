using SnakeGame.RawGraphics;

namespace SnakeGame;

public class GameBoard
{
    private readonly List<Sprite> _sprites = new();
    private readonly Grid _grid;

    public GameBoard(Grid grid, bool wrapAround = false)
    {
        _grid = grid;
    }

    public void AddSprite(Sprite sprite) => _sprites.Add(sprite);

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