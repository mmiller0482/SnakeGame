namespace AsciiGraphics;

public static class GridRenderer
{
    public static void Render(Grid grid)
    {
        ScreenWriter.Clear();
        int yDim = grid.Contents.GetLength(0);
        int xDim = grid.Contents.GetLength(1);
        
        RenderHorizontalBorder(xDim);
        for (int row = yDim -1; row >= 0; row--)
        {
            char[] rowBuffer = new char[xDim];
            for (int col = 0; col < xDim; col++)
            {
                rowBuffer[col] = grid.Contents[row, col];
            }
            ScreenWriter.WriteNormalLine(rowBuffer);
        }
        RenderHorizontalBorder(xDim);
 
    }

    public static void RenderHorizontalBorder(int length)
    {
       char[] rowBuffer = Enumerable.Repeat('=', length).ToArray();
       ScreenWriter.WriteNormalLine(rowBuffer);
    }
}