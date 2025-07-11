﻿public class FleeAction : ICombatAction
{
    public string Name => "Flee";
    public TargetType TargetOfType => TargetType.Self;

    public string GetDescription(Character source)
    {
        return this.Name;
    }

    public void Execute(Character source, Character target)
    {
        source.Statuses.Add(CharacterStatus.Fleeing);
        Console.WriteLine("Run away");
    }
}