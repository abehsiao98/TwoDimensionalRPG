using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.SpatialCoordinates.Enums;
using TwoDimensionalRPG.Utilities;

namespace TwoDimensionalRPG.MapObjects;

public class Character : Role
{
    protected override int MaxHp { get; set; } = GameConfig.Character.MaxHp;
    public override int Hp { get; protected set; } = GameConfig.Character.MaxHp;
    public override void ActualAction()
    {
        while (true)
        {
            var input = Console.ReadKey(intercept: true);
            var action = input.Key switch
            {
                ConsoleKey.UpArrow => (Action)(() => Move(Direction.Up)),
                ConsoleKey.DownArrow => (Action)(() => Move(Direction.Down)),
                ConsoleKey.LeftArrow => (Action)(() => Move(Direction.Left)),
                ConsoleKey.RightArrow => (Action)(() => Move(Direction.Right)),
                ConsoleKey.Spacebar => (Action)(() => Attack()),
                _ => null
            };
            if (action != null)
            {
                action();
                return;
            }
            Console.WriteLine("Invalid action please try again");
        }
    }
    public override void OrderlessAction()
    {
        var isDirectionHorizontal = RandomSingleton.Instance.Next(2) == 1;
        Console.WriteLine($"In a state of orderless you can only move {(isDirectionHorizontal ? "left or right" : "up or down")}");
        while (true)
        {
            var input = Console.ReadKey(intercept: true);
            var action = isDirectionHorizontal ?
                input.Key switch
                {
                    ConsoleKey.LeftArrow => (Action)(() => Move(Direction.Left)),
                    ConsoleKey.RightArrow => (Action)(() => Move(Direction.Right)),
                    _ => null
                } :
                input.Key switch
                {
                    ConsoleKey.UpArrow => (Action)(() => Move(Direction.Up)),
                    ConsoleKey.DownArrow => (Action)(() => Move(Direction.Down)),
                    _ => null
                };

            if (action != null)
            {
                action();
                return;
            }
            Console.WriteLine("Invalid action please try again");
        }
    }
    public override void Attack()
    {
        var IsTargetAheadOfSource = (MapObject source, MapObject target) => Direction switch
        {
            Direction.Up => target.GetCoordinate().X == source.GetCoordinate().X && target.GetCoordinate().Y > source.GetCoordinate().Y,
            Direction.Down => target.GetCoordinate().X == source.GetCoordinate().X && target.GetCoordinate().Y < source.GetCoordinate().Y,
            Direction.Left => target.GetCoordinate().Y == source.GetCoordinate().Y && target.GetCoordinate().X < source.GetCoordinate().X,
            Direction.Right => target.GetCoordinate().Y == source.GetCoordinate().Y && target.GetCoordinate().X > source.GetCoordinate().X,
            _ => false
        };

        var obstacle = Map!.MapObjects.OfType<Obstacle>()
            .OrderBy(o => Math.Abs(Coordinate.X - o.GetCoordinate().X) + Math.Abs(Coordinate.Y - o.GetCoordinate().Y))
            .FirstOrDefault(o => IsTargetAheadOfSource(this, o));

        Map!.MapObjects.OfType<Monster>()
            .Where(m => IsTargetAheadOfSource(this, m) && (obstacle == null || IsTargetAheadOfSource(m, obstacle)))
            .ToList()
            .ForEach(m => m.TakeDamage(GameConfig.Character.Damage));
    }
    public override void AttackAll()
    {
        Map!.MapObjects.OfType<Monster>()
            .ToList()
            .ForEach(m => m.TakeDamage(GameConfig.Character.EruptingDamage));
    }
    public Direction GetCurrentDirection() => Direction;
}