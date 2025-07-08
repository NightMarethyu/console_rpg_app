public class BasicAttackAction : ICombatAction
{
    string ICombatAction.Name => "Basic Attack";

    TargetType ICombatAction.TargetOfType => TargetType.Enemy;

    public void Execute(Character source, Character target)
    {
        source.Attack(target);
    }
}