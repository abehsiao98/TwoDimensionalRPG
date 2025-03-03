using TwoDimensionalRPG.MapObjects.TreasureItems;
using TwoDimensionalRPG.Utilities;
using System.Reflection;

namespace TwoDimensionalRPG.MapObjects;

public class Treasure : MapObject
{
    private static readonly Lazy<IEnumerable<ITreasureItem>> _lazyTreasureItems = new Lazy<IEnumerable<ITreasureItem>>(GetTreasureItems);
    private static readonly Lazy<int> _lazyTotalProbability = new Lazy<int>(() => _lazyTreasureItems.Value.Sum(t => t.Probability));
    private static IEnumerable<ITreasureItem> GetTreasureItems() => Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ITreasureItem).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (ITreasureItem)Activator.CreateInstance(t))!;
    public void Touch(Role role)
    {
        var randomValue = RandomSingleton.Instance.Next(_lazyTotalProbability.Value);
        var cumulativeProbability = 0;
        foreach (var item in _lazyTreasureItems.Value)
        {
            cumulativeProbability += item.Probability;
            if (randomValue <= cumulativeProbability)
            {
                RemoveMapObject();
                item.Effect(role);
                break;
            }
        }
    }
}