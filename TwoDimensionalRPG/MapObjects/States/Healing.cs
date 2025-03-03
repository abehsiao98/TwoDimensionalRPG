using TwoDimensionalRPG.Constants;

namespace TwoDimensionalRPG.MapObjects.States;

public class Healing(Role role) : State(role)
{
    public override void Action()
    {
        Role.Heal(30);
        base.Action();
    }
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState()
    {
        if (IsTakeDamage)
            new Invincible(Role).EntryState();
        else
            new Normal(Role).EntryState();
    }
    protected override bool IsExitState() => Round > GameConfig.State.DurationRound.Healing || IsFullHp || IsTakeDamage;
}