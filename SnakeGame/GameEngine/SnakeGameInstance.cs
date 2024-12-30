using AsciiGraphics;
using static SnakeGame.UserDirection;

namespace SnakeGame.GameEngine;

    
/// <summary>
/// Represents the main game loop and instance manager for the Snake game.
/// Manages rendering, user input, and interaction with game logic components.
/// </summary>   
public class SnakeGameInstance
{
    private readonly Grid _grid;
    private readonly GameBoard _gameBoard;
    private readonly SnakeGameLogic _snakeGameLogic;
    private UserDirection _direction = Right;

    public SnakeGameInstance(int xSize=50, int ySize=30)
    {
        _grid = new Grid(xSize, ySize, ' ');
        _gameBoard = new GameBoard(_grid, true);
        _snakeGameLogic = SnakeGameLogicFactory.Create(new Coordinate2D(1,1), new Coordinate2DFactory(xSize, ySize));
    }
    
    /// <summary>
    /// Starts the game loop, managing rendering, user input, and game updates.
    /// This method runs indefinitely until the application is terminated.
    /// </summary> 
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
    
    /// <summary>
    /// Renders the current game state by plotting all plottable entities onto the game board
    /// and drawing the grid to the console.
    /// </summary>
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
    
    /// <summary>
    /// Introduces a short delay to control the speed of the game loop.
    /// Adjusts the frequency of snake movement and rendering.
    /// </summary>
    private static void SimulateWait()
    {
            Thread.Sleep(100); // Control speed of snake movement
    }
}
