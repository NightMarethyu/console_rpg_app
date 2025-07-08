public interface ICombatAction
{
    string Name { get; }
    TargetType TargetOfType { get; }

    void Execute(Character source, Character target);
}