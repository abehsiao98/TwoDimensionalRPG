using TwoDimensionalRPG;
using TwoDimensionalRPG.MapIcons;
using TwoDimensionalRPG.MapObjects;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var mapObjectList = new List<MapObject>()
{
    new Character(),
    new Monster(),
    new Monster(),
    new Monster(),
    new Treasure(),
    new Treasure(),
    new Treasure(),
    new Treasure(),
    new Treasure(),
    new Obstacle(),
    new Obstacle(),
    new Obstacle(),
    new Obstacle(),
    new Obstacle(),
    new Obstacle(),
};

var mapObjectIcon = new CharacterIcon(new MonsterIcon(new TreasureIcon(new ObstacleIcon(null))));
var map = new Map(mapObjectList, mapObjectIcon);
while (true)
{
    foreach (var role in map.GetMapObjects().OfType<Role>().ToList())
    {
        if (role is Character)
        {
            Console.WriteLine($"The {role.GetType().Name.ToLower()}'s hp is {role.Hp}");
            Console.WriteLine($"The {role.GetType().Name.ToLower()}'s current state state is {role.State.GetType().Name.ToLower()}");
        }
        if (map.IsGameOver())
        {
            Console.WriteLine("Game Over");
            return;
        }
        role.Action();
    }
    map.AddMapObject();
}

