using TwoDimensionalRPG.Constants;
using TwoDimensionalRPG.MapObjects.SpatialCoordinates.Enums;
using TwoDimensionalRPG.Utilities;

namespace TwoDimensionalRPG.MapObjects;

public class Monster : Role
{
    protected override int MaxHp { get; set; } = GameConfig.Monster.MaxHp;
    public override int Hp { get; protected set; } = GameConfig.Monster.MaxHp;
    public override void ActualAction()
    {
        if (Map!.MapObjects.OfType<Character>().Any(c => (Math.Abs(c.GetCoordinate().X - Coordinate.X) == 1 && c.GetCoordinate().Y == Coordinate.Y) || (Math.Abs(c.GetCoordinate().Y - Coordinate.Y) == 1 && c.GetCoordinate().X == Coordinate.X)))
        {
            State.Attack();
            return;
        }
        var direction = (Direction)RandomSingleton.Instance.Next(4);
        Move(direction);
    }
    public override void OrderlessAction()
    {
        if (RandomSingleton.Instance.Next(2) == 1)
            Move(RandomSingleton.Instance.Next(2) == 1 ? Direction.Left : Direction.Right);
        else
            Move(RandomSingleton.Instance.Next(2) == 1 ? Direction.Up : Direction.Down);
    }
    public override void Attack()
    {
        Map!.MapObjects.OfType<Character>()
            .Where(c => Map.MapObjects.OfType<Character>().Any(c => (Math.Abs(c.GetCoordinate().X - Coordinate.X) == 1 && c.GetCoordinate().Y == Coordinate.Y) || (Math.Abs(c.GetCoordinate().Y - Coordinate.Y) == 1 && c.GetCoordinate().X == Coordinate.X)))
            .ToList()
            .ForEach(c => c.TakeDamage(GameConfig.Monster.Damage));
    }
    public override void AttackAll()
    {
        Map!.MapObjects.OfType<Character>()
            .ToList()
            .ForEach(m => m.TakeDamage(GameConfig.Monster.EruptingDamage));
    }
}