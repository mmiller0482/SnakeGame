namespace SnakeGame.RawGraphics;

public static class GridRenderer
{
    public static void Render(Grid grid)
    {
        ScreenWriter.Clear();
        for (int row = grid.Contents.GetLength(0) -1; row >= 0; row--)
        {
            char[] rowBuffer = new char[grid.Contents.GetLength(1)];
            for (int col = 0; col < grid.Contents.GetLength(1); col++)
            {
                rowBuffer[col] = grid.Contents[row, col];
            }
            ScreenWriter.WriteNormalLine(rowBuffer);
        }
 
    }
}