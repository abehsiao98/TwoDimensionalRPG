using TwoDimensionalRPG.MapObjects.SpatialCoordinates;
using TwoDimensionalRPG.MapObjects.SpatialCoordinates.Enums;
using TwoDimensionalRPG.MapObjects.States;
using TwoDimensionalRPG.Utilities;

namespace TwoDimensionalRPG.MapObjects;

public abstract class Role : MapObject
{
    private bool IsDead;
    protected Direction Direction { get; private set; }
    public State State { get; private set; }
    protected abstract int MaxHp { get; set; }
    public abstract int Hp { get; protected set; }
    protected Role()
    {
        Direction = (Direction)RandomSingleton.Instance.Next(4);
        State = new Normal(this);
    }
    public abstract void ActualAction();
    public abstract void OrderlessAction();
    public abstract void Attack();
    public abstract void AttackAll();
    protected override void RemoveMapObject()
    {
        base.RemoveMapObject();
        IsDead = true;
    }
    public void Action()
    {
        State.RoundHandle();
        State.Action();
    }
    public void Move(Direction direction)
    {
        Direction = direction;
        (bool isValid, int x, int y) = Coordinate.TryMove(direction);
        if (isValid)
            Coordinate.Move(x, y);
        else
        {
            var treasure = Map!.MapObjects.OfType<Treasure>().FirstOrDefault(m => m.GetCoordinate().X == x && m.GetCoordinate().Y == y);
            treasure?.Touch(this);
        }
    }
    public void TakeDamage(int damage)
    {
        ReduceHp(damage);
        if (!IsDead)
            State.OnDamageTaken();
    }
    public void ReduceHp(int damage)
    {
        Hp = Math.Max(Hp - State.DamageHandle(damage), 0);
        if (Hp == 0)
            RemoveMapObject();
    }
    public void Heal(int amount)
    {
        Hp = Math.Min(Hp + amount, MaxHp);
        if (Hp == MaxHp)
            State.OnHpHealToFull();
    }
    public bool IsRoleDead() => IsDead;
    public void SetState(State state) => State = state;
}