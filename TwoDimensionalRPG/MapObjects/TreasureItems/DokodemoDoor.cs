using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.States;

namespace TwoDimensionalRPG.MapObjects.TreasureItems;

public class DokodemoDoor : ITreasureItem
{
    public int Probability { get; private set; } = GameConfig.Treasure.Probability.DokodemoDoor;
    public void Effect(Role role) => role.SetState(new Teleport(role));
}