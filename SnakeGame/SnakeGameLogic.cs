using SnakeGame.RawGraphics;

namespace SnakeGame;


public class SnakeGameLogic
{
    private readonly Snake _snake;
    private readonly Coordinate2DFactory _coordinate2DFactory;
    private readonly IPlottable?[] _plottables;
    private int _cycles;

    public SnakeGameLogic(Snake snake, Coordinate2DFactory coordinate2DFactory)
    {
        _coordinate2DFactory = coordinate2DFactory;
        _snake = snake;
        _plottables = [_snake];
        _cycles = 0;
    }
    
    public IEnumerable<IPlottable?>  Plottables => _plottables;

    public void Update(UserDirection direction)
    {
        _cycles++;
        if (_cycles % 10 == 0)
        {
            _snake.EatFood();
        }
        _snake.Move(direction);

        if (_snake.SelfCollision())
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        _snake.Reset();
    }
}