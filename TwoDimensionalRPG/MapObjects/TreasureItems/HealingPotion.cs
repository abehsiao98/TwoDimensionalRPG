using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.States;

namespace TwoDimensionalRPG.MapObjects.TreasureItems;

public class HealingPotion : ITreasureItem
{
    public int Probability { get; private set; } = GameConfig.Treasure.Probability.HealingPotion;
    public void Effect(Role role) => role.SetState(new Healing(role));
}