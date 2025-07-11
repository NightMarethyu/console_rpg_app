public class BasicDefendAction : ICombatAction
{
    public string Name => "Basic Defend";
    public TargetType TargetOfType => TargetType.Self;

    public string GetDescription(Character source)
    {
        return this.Name;
    }

    public void Execute(Character source, Character target)
    {
        source.Statuses.Add(CharacterStatus.Defending);
        Console.WriteLine("Guarding");
    }
}