using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.States;

namespace TwoDimensionalRPG.MapObjects.TreasureItems;

public class SuperStar : ITreasureItem
{
    public int Probability { get; private set; } = GameConfig.Treasure.Probability.SuperStar;
    public void Effect(Role role) => role.SetState(new Invincible(role));
}