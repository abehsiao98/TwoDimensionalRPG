using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.States;

namespace TwoDimensionalRPG.MapObjects.TreasureItems;

public class KingsRock : ITreasureItem
{
    public int Probability { get; private set; } = GameConfig.Treasure.Probability.KingsRock;
    public void Effect(Role role) => role.SetState(new Stockpile(role));
}