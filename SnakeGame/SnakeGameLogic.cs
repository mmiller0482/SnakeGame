using AsciiGameEngine;
using AsciiGraphics;

namespace SnakeGame;


public class SnakeGameLogic : IAsciiGameLogic
{
    private readonly Snake _snake;
    private readonly FoodGen _foodGen;
    private Sprite? _food;

    public SnakeGameLogic(Snake snake, Coordinate2DFactory coordinate2DFactory)
    {
        _snake = snake;
        _foodGen = new FoodGen(coordinate2DFactory);
    }

    public IEnumerable<IPlottable?> Plottables => [_snake, _food];

    public void Update(UserDirection direction)
    {
        _food ??= GenerateFood();
        if (_snake.CoordinateAtHead(_food.Position))
        {
            _snake.EatFood();
            _food = GenerateFood();
        }
        _snake.Move(direction);

        if (_snake.SelfCollision())
        {
            ResetGame();
        }
    }

    private Sprite GenerateFood() => _foodGen.RandomFood(_snake.Segments);

    private void ResetGame()
    {
        _snake.Reset();
    }
}