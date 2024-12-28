using System.Drawing;
using SnakeGame.RawGraphics;

namespace SnakeGame;

public class SnakeGameInstance
{
    private Grid _grid;
    private GameBoard _gameBoard;
    private Snake _snake;
    private UserDirection _direction = UserDirection.Right;
    private Coordinate2D _sentinelCoordinate = new Coordinate2D(1, 1);
    private Coordinate2DFactory _coordinate2DFactory;

    public SnakeGameInstance(int xSize=30, int ySize=30)
    {
        _grid = new Grid(xSize, ySize, ' ');
        _sentinelCoordinate = new Coordinate2D(1, 1);
        _gameBoard = new GameBoard(_grid, true);
        _coordinate2DFactory = new Coordinate2DFactory(xSize, ySize);
        _snake = new Snake(_sentinelCoordinate, _coordinate2DFactory);
    }
    public void Run()
    {
        int cycles = 0;
        while (true)
        {
            Draw();
            SimulateWait();
            GetUserDirection();
            // Operations for this cycle
            if (cycles % 10 == 0)
            {
                _snake.EatFood();
            }
            _snake.Move(_direction);
            if (_snake.SelfCollision())
            {
                _snake.Reset();
            }
            _gameBoard.Clear();
            cycles++;
        }
    }

    private void SimulateWait()
    {
            System.Threading.Thread.Sleep(50); // Control speed of snake movement
    }
    private void Draw()
    {
        _snake.SendToGameBoard(_gameBoard); 
        _gameBoard.Render();
        GridWriter.Draw(_grid);
    }

    private void GetUserDirection()
    {
        if (Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(intercept: true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _direction = UserDirection.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _direction = UserDirection.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    _direction = UserDirection.Left;
                    break;
                case ConsoleKey.RightArrow:
                    _direction = UserDirection.Right;
                    break;
            }
        } 
    }
    
    
}