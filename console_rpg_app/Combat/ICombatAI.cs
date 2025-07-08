public interface ICombatAI
{
    (ICombatAction action, Guid targetID) ChooseAction(CombatState state);
}