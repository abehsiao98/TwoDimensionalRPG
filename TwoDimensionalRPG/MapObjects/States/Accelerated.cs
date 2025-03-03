using TwoDimensionalRPG.Constants;

namespace TwoDimensionalRPG.MapObjects.States;

public class Accelerated(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState() => new Normal(Role).EntryState();
    public override void Action()
    {
        base.Action();
        base.Action();
    }
    protected override bool IsExitState() => Round > GameConfig.State.DurationRound.Accelerated || IsTakeDamage;
}