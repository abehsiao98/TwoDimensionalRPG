using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.States;

namespace TwoDimensionalRPG.MapObjects.TreasureItems;

public class DevilFruit : ITreasureItem
{
    public int Probability { get; private set; } = GameConfig.Treasure.Probability.DevilFruit;
    public void Effect(Role role) => role.SetState(new Orderless(role));
}