namespace TwoDimensionalRPG.MapObjects.States;

public class Normal(Role role) : State(role)
{
    public override void EntryState() => Role.SetState(this);
    protected override void ExitState()
    {
        if (IsTakeDamage)
            new Invincible(Role).EntryState();
    }
    protected override bool IsExitState() => IsTakeDamage;
}