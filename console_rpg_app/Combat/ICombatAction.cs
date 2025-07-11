public interface ICombatAction
{
    string Name { get; }
    TargetType TargetOfType { get; }
    string GetDescription(Character source);

    void Execute(Character source, Character target);
}