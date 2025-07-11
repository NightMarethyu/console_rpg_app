public class BasicAttackAction : ICombatAction
{
    public string Name => "Basic Attack";

    TargetType ICombatAction.TargetOfType => TargetType.Enemy;

    public string GetDescription(Character source)
    {
        return $"{Name} (Damage: {source.AttackValue})";
    }

    public void Execute(Character source, Character target)
    {
        source.Attack(target);
    }
}