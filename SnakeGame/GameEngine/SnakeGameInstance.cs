using SnakeGame.RawGraphics;
using static SnakeGame.UserDirection;

namespace SnakeGame.GameEngine;

public class SnakeGameInstance
{
    private readonly Grid _grid;
    private readonly GameBoard _gameBoard;
    private readonly SnakeGameLogic _snakeGameLogic;
    private UserDirection _direction = Right;

    public SnakeGameInstance(int xSize=30, int ySize=30)
    {
        _grid = new Grid(xSize, ySize, ' ');
        _gameBoard = new GameBoard(_grid, true);
        _snakeGameLogic = SnakeGameLogicFactory.Create(new Coordinate2D(1,1), new Coordinate2DFactory(xSize, ySize));
    }
    
    public void Run()
    {
        while (true)
        {
            // Always Render First
            Render();
            SimulateWait();
            GetUserDirection();
            _snakeGameLogic.Update(_direction);
            _gameBoard.Clear();
        }
    }

    private void Render()
    {
        foreach (IPlottable? plottable in _snakeGameLogic.Plottables)
        {
            plottable?.Plot(_gameBoard);
        }
        _gameBoard.Render();
        GridRenderer.Render(_grid);
    }

    private void GetUserDirection()
    {
        if (!Console.KeyAvailable) return;
        var keyInfo = Console.ReadKey(intercept: true);
        _direction = keyInfo.Key switch
        {
            ConsoleKey.UpArrow => Up,
            ConsoleKey.DownArrow => Down,
            ConsoleKey.LeftArrow => Left,
            ConsoleKey.RightArrow => Right,
            _ => _direction
        };
    }
    private static void SimulateWait()
    {
            Thread.Sleep(50); // Control speed of snake movement
    }
    
    
}