
using AsciiGraphics;

namespace SnakeGame;

public class FoodGen
{
    private const char DefaultFoodSymbol = 'X';
    private readonly char _foodSymbol;
    private readonly Coordinate2DFactory _coordinate2DFactory;


    public FoodGen(Coordinate2DFactory coordinateFactory, char foodSymbol = DefaultFoodSymbol)
    {
        _coordinate2DFactory = coordinateFactory;
        _foodSymbol = foodSymbol;
    }

    public Sprite RandomFood() => RandomFood([]);
    
    public Sprite RandomFood(IEnumerable<Coordinate2D> lockoutCoordinates) 
        => new Sprite(_coordinate2DFactory.CreateRandom(lockoutCoordinates), _foodSymbol);
    
}