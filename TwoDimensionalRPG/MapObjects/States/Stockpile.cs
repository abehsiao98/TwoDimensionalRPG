using TwoDimensionalRPG.Constants;

namespace TwoDimensionalRPG.MapObjects.States;

public class Stockpile(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState()
    {
        if (IsTakeDamage)
            new Normal(Role).EntryState();
        else
            new Erupting(Role).EntryState();
    }
    protected override bool IsExitState() => Round > GameConfig.State.DurationRound.Stockpile || IsTakeDamage;
}