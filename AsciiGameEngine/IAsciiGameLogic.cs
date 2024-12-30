using AsciiGraphics;

namespace AsciiGameEngine;

public interface IAsciiGameLogic
{
    public IEnumerable<IPlottable?> Plottables { get; }
    void Update(UserDirection direction);
    
}