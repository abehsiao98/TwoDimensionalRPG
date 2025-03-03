using TwoDimensionalRPG.Constants;

namespace TwoDimensionalRPG.MapObjects.States;

public class Invincible(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState() => new Normal(Role).EntryState();
    protected override bool IsExitState() => Round > GameConfig.State.DurationRound.Invincible;
    public override int DamageHandle(int damage) => 0;
}