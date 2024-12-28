using SnakeGame.RawGraphics;

namespace SnakeGame;

public static class SnakeGameLogicFactory
{
    public static SnakeGameLogic Create(Coordinate2D startPosition, Coordinate2DFactory coordinate2DFactory)
    {
        Snake snake = new Snake(startPosition, coordinate2DFactory);
        return new SnakeGameLogic(snake, coordinate2DFactory);
    }
}