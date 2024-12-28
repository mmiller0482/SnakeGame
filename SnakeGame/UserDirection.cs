namespace SnakeGame;

public static class UserDirectionOps
{
    public static UserDirection Opposite(UserDirection direction)
    {
        switch (direction)
        {
            case UserDirection.Up:
                return UserDirection.Down;
            case UserDirection.Down:
                return UserDirection.Up;
            case UserDirection.Left:
                return UserDirection.Right;
            case UserDirection.Right:
                
                return UserDirection.Left;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}

public enum UserDirection
{
    Up,
    Down,
    Left,
    Right
}