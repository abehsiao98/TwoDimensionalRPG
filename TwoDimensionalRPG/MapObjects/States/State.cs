namespace TwoDimensionalRPG.MapObjects.States;

public abstract class State
{
    protected Role Role;
    protected int Round { get; private set; }
    protected bool IsTakeDamage { get; private set; }
    protected bool IsFullHp { get; private set; }
    protected State(Role role) => Role = role;
    public abstract void EntryState();
    protected abstract bool IsExitState();
    protected abstract void ExitState();
    public void OnDamageTaken() => IsTakeDamage = true;
    public void OnHpHealToFull() => IsFullHp = true;
    public void RoundHandle()
    {
        Round++;
        if (IsExitState())
        {
            ExitState();
            Round = 0;
        }
    }
    public virtual int DamageHandle(int damage) => damage;
    public virtual void Action()
    {
        if (Role.IsRoleDead())
            return;
        if (Role is Character)
            Role.GetMap().GenerateMap();
        Role.ActualAction();
    }
    public virtual void Attack() => Role.Attack();
}