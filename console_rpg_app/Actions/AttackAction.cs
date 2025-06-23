public class AttackAction : IGameAction
{
    public string Description { get; }
    private readonly Character _attacker;
    private readonly Character _target;

    public AttackAction(Character attacker, Character target)
    {
        _attacker = attacker;
        _target = target;
        Description = $"Attack {_target.Name}";
    }

    public void Execute()
    {
        _attacker.Attack(_target);
    }
}