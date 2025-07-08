
public class SimpleAgressiveAI : ICombatAI
{
    public (ICombatAction action, Guid targetID) ChooseAction(CombatState state)
    {
        var attackAction = state.Self.combatActions.OfType<BasicAttackAction>().FirstOrDefault();
        if (attackAction == null) { return (null, Guid.Empty); }

        Guid targetId = state.EnemyIds.FirstOrDefault();

        if (targetId == Guid.Empty) { return (null, Guid.Empty); }

        return (attackAction, targetId);
    }
}