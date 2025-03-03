using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects;

namespace TwoDimensionalRPG.MapIcons;

public class MonsterIcon(MapIcon? next) : MapIcon(next)
{
    protected override bool IsMatch(MapObject? mapObject) => mapObject is Monster;
    protected override void Action(MapObject? mapObject) => Console.Write(GameConfig.Monster.Icon);
}