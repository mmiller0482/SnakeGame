using SnakeGame.RawGraphics;

namespace SnakeGame;

public class Snake : IPlottable
{
    private readonly Coordinate2D _startPosition; 
    private const char SnakeSegmentSymbol = '#';
    
    private readonly LinkedList<Coordinate2D> _body = [];

    private bool _shouldEat;
    private UserDirection _prevDirection = UserDirection.Right;
    private readonly Coordinate2DFactory _coordinate2DFactory;
    

    // TODO: Add another constructor using a default "nonwrapped" coordinate factory when available.
    public Snake(Coordinate2D startPosition, Coordinate2DFactory coordinate2DFactory)
    {
        _body.AddFirst(startPosition);
        _startPosition = startPosition;
        _coordinate2DFactory = coordinate2DFactory;
    }

    public Coordinate2D Head
    {
        get
        {
            if (_body.First == null)
            {
                throw new InvalidOperationException("The snake has no head because its body is empty.");
            }
            return _body.First.Value;
        }
    }

    public Coordinate2D Tail
    {
        get
        {
            if (_body.Last == null)
            {
                throw new InvalidOperationException("The snake has no tail because its body is empty.");
            }
            return _body.Last.Value;
        }
    } 
    
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

    public void Plot(GameBoard gameBoard)
    {
        foreach (Coordinate2D segment in _body)
        { 
            Sprite segmentSprite = new Sprite(segment, SnakeSegmentSymbol);
            segmentSprite.Plot(gameBoard);
        }
    }

    public void Reset()
    {
        _shouldEat = false;
        _body.Clear();
        _body.AddFirst(_startPosition);
    }

    public bool CoordinateOnSnake(Coordinate2D coordinate) => _body.Any(segment => Equals(segment, coordinate));

    public bool CoordinateAtHead(Coordinate2D coordinate) => Equals(coordinate, Head);
    public bool CoordinateAtTail(Coordinate2D coordinate) => Equals(coordinate, Tail);
    
    public bool SelfCollision()
        // single point cannot collide with itself.
        =>  Length > 1 && _body.Skip(1).Any(segment => Equals(segment, Head));

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