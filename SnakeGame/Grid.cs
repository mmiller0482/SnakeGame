namespace SnakeGame;

public class Grid
{
    private const int XDefault = 20;
    private const int YDefault = 20;

    public int XSize { get; }
    public int YSize { get; }
    public char[,] Contents { get; }
    

    public Grid(int xSize, int ySize, char defaultCellValue)
    {
        XSize = xSize;
        YSize = ySize;
        Contents = RawGridInitializer(XSize, YSize, defaultCellValue);
    }

    public Grid(char defaultCellValue) : this(XDefault, YDefault, defaultCellValue) { }
    
    public Grid(int xValue, int yValue) : this(xValue, yValue, ' ') { }
    
    public Grid(int squareValue) : this(squareValue, squareValue, ' ') { }
    
    public Grid(int squareValue, char defaultCellValue) : this(squareValue, squareValue, defaultCellValue) { }


    public void SetCell(int x, int y, char value)
    {
        Contents[x, y] = value;
    }
    
    private static char[,] RawGridInitializer(int xSize, int ySize, char defaultValue)
    {
        char[,] grid = new char[xSize, ySize];
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                grid[x, y] = defaultValue;
            }
        }
        
        return grid;
    }
}

