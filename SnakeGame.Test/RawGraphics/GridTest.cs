using SnakeGame.RawGraphics;

namespace SnakeGame.Test.RawGraphics;

public class GridTest
{
    [Fact]
    public void Test_Init_AllArgs()
    {
        int x = 2;
        int y = 2;
        char @default = '&';
        char[,] expected =
        {
            { '&', '&' },
            { '&', '&' },
        };
        
        Grid gut = new(x, y, @default);

        Assert.Equal(expected, gut.Contents);
    }

    [Fact]
    public void TestSetCell_Valid()
    {
        Grid gut = Get2By2Grid('&');
        Coordinate2D coordinate = new(0, 0);
        char[,] expected =
        {
            {'#', '&'},
            {'&', '&'},
        };

        gut.SetCell(coordinate, '#');
        
        Assert.Equal(expected, gut.Contents);
    }
    [Fact]
    public void TestSetCell_Coordinate_Valid()
    {
        Grid gut = Get2By2Grid('&');
        char[,] expected =
        {
            {'#', '&'},
            {'&', '&'},
        };

        gut.SetCell(new Coordinate2D(0, 0), '#');
        
        Assert.Equal(expected, gut.Contents);
    }


    private static Grid Get2By2Grid(char @default)
    {
        return new Grid(2, 2, @default);
    }
}