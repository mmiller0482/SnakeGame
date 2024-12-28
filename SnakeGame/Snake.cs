using SnakeGame.RawGraphics;

namespace SnakeGame;

public class Snake
{
    private readonly Coordinate2D _startPosition; 
    private const char SnakeSegmentSymbol = '#';
    
    private readonly LinkedList<Coordinate2D> _body = [];

    private bool _shouldEat = false;
    private UserDirection _prevDirection = UserDirection.Right;
    private Coordinate2DFactory _coordinate2DFactory;
    

    // TODO: Add another constructor using a default "nonwrapped" coordinate factory when available.
    public Snake(Coordinate2D startPosition, Coordinate2DFactory coordinate2DFactory)
    {
        _body.AddFirst(startPosition);
        _startPosition = startPosition;
        _coordinate2DFactory = coordinate2DFactory;
    }

    // TODO: Probably need some better behavior when a snake has empty body.
    public Coordinate2D Head => _body.FirstOrDefault(new Coordinate2D(0, 0));
    
    // TODO: Probably need some better behavior when a snake has empty body.
    public Coordinate2D Tail => _body.LastOrDefault(new Coordinate2D(0, 0));
    
    public int Length => _body.Count;

    public void EatFood()
    {
        _shouldEat = true;
    }

    public void Move(UserDirection userDirection)
    {
        if (UserDirectionOps.Opposite(userDirection) == _prevDirection)
        {
            userDirection = _prevDirection;
        }
        
        _prevDirection = userDirection;
        
        switch (userDirection)
        {
            case UserDirection.Up:
                PointAndMoveUp();
                break;
            case UserDirection.Down:
                PointAndMoveDown();
                break;
            case UserDirection.Left:
                PointAndMoveLeft();
                break;
            case UserDirection.Right:
                PointAndMoveRight();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(userDirection), userDirection, null);
        }
    }

    private void PointAndMoveUp() => SnakeTranslate(0, 1);

    private void PointAndMoveDown() => SnakeTranslate(0, -1);

    private void PointAndMoveLeft() => SnakeTranslate(-1, 0);

    private void PointAndMoveRight() => SnakeTranslate(1, 0);

    public void SendToGameBoard(GameBoard gameBoard)
    {
        foreach (Coordinate2D segment in _body)
        {
            gameBoard.AddSprite(new Sprite(segment, SnakeSegmentSymbol));
        }
    }

    public void Reset()
    {
        _shouldEat = false;
        _body.Clear();
        _body.AddFirst(_startPosition);
    }

    public bool SelfCollision()
    {
        if (Length <= 1)
        {
            return false; // single point cannot collide with itself.
        }
        return _body.Skip(1).Any(segment => Equals(segment, Head));
    }

    private void SnakeTranslate(int xMove, int yMove)
    {
        Coordinate2D newHead = _coordinate2DFactory.Create(Head.X + xMove, Head.Y + yMove);
        _body.AddFirst(newHead);
        if (_shouldEat)
        {
            _shouldEat = false;
        }
        else
        {
            _body.RemoveLast();
        }
    }
}