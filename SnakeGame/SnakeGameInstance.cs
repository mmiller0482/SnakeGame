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

    public SnakeGameInstance()
    {
        _grid = new Grid(100, 30, ' ');
        _gameBoard = new GameBoard(_grid, true);
        _snake = new Snake(_sentinelCoordinate);
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