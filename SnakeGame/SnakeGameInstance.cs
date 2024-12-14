namespace SnakeGame;

public class SnakeGameInstance
{
    private Grid _grid;
    private Snake _snake;

    public SnakeGameInstance()
    {
        _grid = new Grid(20, 80, ' ');
        _snake = new Snake(new Coordinate2D(5, 30));
    }

    public void Run()
    {
        int cycles = 0;
        while (cycles < 100)
        {
            Draw();
            
            
            cycles++;
        }
    }
    private void Draw()
    {
        
    }
    
    
}