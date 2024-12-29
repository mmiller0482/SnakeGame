using SnakeGame.RawGraphics;

namespace SnakeGame;


public class SnakeGameLogic
{
    private readonly Snake _snake;
    private Sprite? _food;
    private readonly Coordinate2DFactory _coordinate2DFactory;
    private readonly FoodGen _foodGen;
    private int _xMax; 
    private int _yMax;
    private Random _random;

    public SnakeGameLogic(Snake snake, Coordinate2DFactory coordinate2DFactory)
    {
        _coordinate2DFactory = coordinate2DFactory;
        _snake = snake;
        _xMax = coordinate2DFactory.XMax;
        _yMax = coordinate2DFactory.YMax;
        _random = new Random();
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

    private Sprite GenerateFood()
    {
        Sprite food;
        do
        {
            // generate x
            int foodLocX = _random.Next(0, _xMax);
            // generate y
            int foodLocY = _random.Next(0, _yMax);
            food = _foodGen.FoodAt(foodLocX, foodLocY);
            
        } while (_snake.CoordinateOnSnake(food.Position));
        return food;
    }

    private void ResetGame()
    {
        _snake.Reset();
    }
}