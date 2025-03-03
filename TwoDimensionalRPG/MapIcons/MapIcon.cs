using TwoDimensionalRPG.MapObjects;

namespace TwoDimensionalRPG.MapIcons;

public abstract class MapIcon
{
    private MapIcon? _next;
    protected MapIcon(MapIcon? next) => _next = next;
    public void Print(MapObject? mapObject)
    {
        if (IsMatch(mapObject))
            Action(mapObject);
        else if (_next != null)
            _next.Print(mapObject);
        else
            Console.Write("_");
    }
    protected abstract bool IsMatch(MapObject? mapObject);
    protected abstract void Action(MapObject? mapObject);
}