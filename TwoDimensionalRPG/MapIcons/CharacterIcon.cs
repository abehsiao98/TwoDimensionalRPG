using TwoDimensionalRPG.MapObjects;
using TwoDimensionalRPG.MapObjects.SpatialCoordinates.Enums;

namespace TwoDimensionalRPG.MapIcons;
public class CharacterIcon(MapIcon? next) : MapIcon(next)
{
    protected override bool IsMatch(MapObject? mapObject) => mapObject is Character;
    protected override void Action(MapObject? mapObject)
    {
        var character = mapObject as Character;
        var icon = character!.GetCurrentDirection() switch
        {
            Direction.Up => "↑",
            Direction.Down => "↓",
            Direction.Left => "←",
            Direction.Right => "→",
            _ => string.Empty
        };
        Console.Write(icon);
    }
}