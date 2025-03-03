using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects;

namespace TwoDimensionalRPG.MapIcons;

public class TreasureIcon(MapIcon? next) : MapIcon(next)
{
    protected override bool IsMatch(MapObject? mapObject) => mapObject is Treasure;
    protected override void Action(MapObject? mapObject) => Console.Write(GameConfig.Treasure.Icon);
}