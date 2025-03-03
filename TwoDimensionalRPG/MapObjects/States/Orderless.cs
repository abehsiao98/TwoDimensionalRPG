using TwoDimensionalRPG.Constants;

namespace TwoDimensionalRPG.MapObjects.States;

public class Orderless(Role role) : State(role)
{
    public override void Action()
    {
        if (Role.IsRoleDead())
            return;
        if (Role is Character)
            Role.GetMap().GenerateMap();
        Role.OrderlessAction();
    }
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState()
    {
        if (IsTakeDamage)
            new Invincible(Role).EntryState();
        else
            new Normal(Role).EntryState();
    }
    protected override bool IsExitState() => Round > GameConfig.State.DurationRound.Orderless || IsTakeDamage;
}