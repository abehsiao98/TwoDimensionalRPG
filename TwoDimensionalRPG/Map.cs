using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapIcons;
using TwoDimensionalRPG.MapObjects;
using TwoDimensionalRPG.Utilities;

namespace TwoDimensionalRPG;

public class Map
{
    private MapIcon _mapIcon;
    public List<MapObject> MapObjects { get; private set; } = new();
    public Map(List<MapObject> mapObjects, MapIcon mapIcon)
    {
        MapObjects = mapObjects;
        foreach (MapObject mapObject in mapObjects)
        {
            mapObject.SetMap(this);
        }
        _mapIcon = mapIcon;
    }
    public void GenerateMap()
    {
        for (var height = GameConfig.Map.MaxHeight - 1; height >= 0; height--)
        {
            for (var width = 0; width < GameConfig.Map.MaxWidth; width++)
            {
                var mapObject = MapObjects.Where(o => o.GetCoordinate().X == width && o.GetCoordinate().Y == height)
                    .FirstOrDefault();
                _mapIcon.Print(mapObject);
            }
            Console.WriteLine();
        }
    }
    public void AddMapObject()
    {
        if (RandomSingleton.Instance.Next(10) != 0)
            return;
        var mapObject = (MapObject)(RandomSingleton.Instance.Next(2) == 1 ? new Monster() : new Treasure());
        mapObject.SetMap(this);
        MapObjects.Add(mapObject);
    }
    public void RemoveMapObject(MapObject mapObject)
    {
        if (MapObjects.Contains(mapObject))
            MapObjects.Remove(mapObject);
    }

    public List<MapObject> GetMapObjects() => MapObjects;
    public bool IsGameOver() => MapObjects.OfType<Character>().All(c => c.IsRoleDead()) || MapObjects.OfType<Monster>().All(m => m.IsRoleDead());
}
