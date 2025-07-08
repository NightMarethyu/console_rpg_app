public class FleeAction : ICombatAction
{
    public string Name => "Flee";
    public TargetType TargetOfType => TargetType.Self;

    public void Execute(Character source, Character target)
    {
        Console.WriteLine("Run away");
    }
}