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
        foreach (IPlottable plottable in _snakeGameLogic.Plottables)
        {
            plottable?.Plot(_gameBoard);
        }
        _gameBoard.Render();
        GridRenderer.Render(_grid);
    }

    private void GetUserDirection()
    {
        if (Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(intercept: true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _direction = Up;
                    break;
                case ConsoleKey.DownArrow:
                    _direction = Down;
                    break;
                case ConsoleKey.LeftArrow:
                    _direction = Left;
                    break;
                case ConsoleKey.RightArrow:
                    _direction = Right;
                    break;
            }
        } 
    }
    private void SimulateWait()
    {
            System.Threading.Thread.Sleep(50); // Control speed of snake movement
    }
    
    
}
