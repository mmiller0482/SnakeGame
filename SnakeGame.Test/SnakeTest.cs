using AsciiGameEngine;
using AsciiGraphics;

namespace SnakeGame.Test;

public class SnakeTest
{
    [Fact]
    public void InitNewSnake()
    {
        Snake snake = new Snake(new Coordinate2D(0, 0));
        
        Assert.Equal(1, snake.Length);
        Assert.Equal(new Coordinate2D(0, 0), snake.Head);
        Assert.Equal(new Coordinate2D(0, 0), snake.Tail);
    }

    [Theory]
    [InlineData(UserDirection.Left, -1,0)]
    [InlineData(UserDirection.Right, 1,0)]
    [InlineData(UserDirection.Up, 0,1)]
    [InlineData(UserDirection.Down, 0,-1)]
    public void TranslateInitialSnake(UserDirection direction, int xExpect, int yExpect)
    {
        Snake snake = new Snake(new Coordinate2D(0,0));
        snake.Move(direction);
        Coordinate2D expected = new Coordinate2D(xExpect, yExpect);
        Assert.Equal(expected, snake.Head);
    }

    [Fact]
    public void SnakeLengthAfterEatTranslate()
    {
        Snake snake = new Snake(new Coordinate2D(0, 0));
        snake.EatFood();
        snake.Move(UserDirection.Left);
        
        Assert.Equal(2, snake.Length);
    }

    [Fact]
    public void SnakeSelfCollisionLength1()
    {
        Snake snake = new Snake(new Coordinate2D(0, 0));
        Assert.False(snake.SelfCollision());
    }

    [Fact]
    public void SnakeSelfCollisionLength2()
    {
        Snake snake = new Snake(new Coordinate2D(0, 0));
        // left
        snake.EatFood();
        snake.Move(UserDirection.Left);
        Assert.Equal(2, snake.Length);
        Assert.False(snake.SelfCollision());
    }
    [Fact]
    public void SnakeSelfCollision_True()
    {
        Snake snake = new Snake(new Coordinate2D(0, 0));
        // left
        snake.EatFood();
        snake.Move(UserDirection.Left);
        // down
        snake.EatFood();
        snake.Move(UserDirection.Down);
        //right
        snake.EatFood();
        snake.Move(UserDirection.Right);
        // up
        snake.EatFood();
        snake.Move(UserDirection.Up);
        
        Assert.True(snake.SelfCollision());
    }

}

public static class SnakeBuilder
{
    public static Snake BuildFlatSnake(int length) => BuildFlatSnake(length, UserDirection.Right);
    public static Snake BuildFlatSnake(int length, UserDirection userDirection)
    {
        // Start a new snake at the origin.
        Coordinate2D startPosition = new Coordinate2D(0, 0);
        Snake newSnake = new Snake(startPosition);
        
        // move the snake to the right length number of times.
        for (int i = 0; i < length; i++)
        {
            newSnake.Move(userDirection);
        }
        return newSnake;
    }
}