using TwoDimensionalRPG.Constants;

namespace TwoDimensionalRPG.MapObjects.States;

public class Erupting(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState()
    {
        if (IsTakeDamage)
            new Invincible(Role).EntryState();
        else
            new Teleport(Role).EntryState();
    }
    protected override bool IsExitState() => Round > GameConfig.State.DurationRound.Erupting || IsTakeDamage;
    public override void Attack() => Role.AttackAll();
}