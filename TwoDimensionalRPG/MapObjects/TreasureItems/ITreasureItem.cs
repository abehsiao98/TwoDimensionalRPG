namespace TwoDimensionalRPG.MapObjects.TreasureItems;

public interface ITreasureItem
{
    public int Probability { get; }
    public void Effect(Role role);
}