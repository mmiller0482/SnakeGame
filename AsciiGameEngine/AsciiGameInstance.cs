using AsciiGraphics;
using static AsciiGameEngine.UserDirection;

namespace AsciiGameEngine;

    
/// <summary>
/// Represents the main game loop and instance manager for the ascii game.
/// Manages rendering, user input, and interaction with game logic components.
/// </summary>   
public class AsciiGameInstance
{
    private readonly Grid _grid;
    private readonly GameBoard _gameBoard;
    private readonly IAsciiGameLogic _asciiGameLogic;
    private UserDirection _direction = Right;

    public AsciiGameInstance(int xSize, int ySize, IAsciiGameLogic asciiGameLogic)
    {
        _grid = new Grid(xSize, ySize, ' ');
        _gameBoard = new GameBoard(_grid, true);
        _asciiGameLogic = asciiGameLogic;
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
            _asciiGameLogic.Update(_direction);
            _gameBoard.Clear();
        }
    }
    
    /// <summary>
    /// Renders the current game state by plotting all plottable entities onto the game board
    /// and drawing the grid to the console.
    /// </summary>
    private void Render()
    {
        foreach (IPlottable? plottable in _asciiGameLogic.Plottables)
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
    /// </summary>
    private static void SimulateWait()
    {
            // TODO: Make this sleep time configurable & changeable.
            Thread.Sleep(100); // Control speed of snake movement
    }
}
