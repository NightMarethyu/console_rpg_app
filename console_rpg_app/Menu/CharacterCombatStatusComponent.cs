public record CharacterCombatStatusComponent(Character Character) : IViewComponent
{
    public void Render()
    {
        Console.WriteLine(GameStrings.CombatStrings.CharacterStatus, Character.Name, Character.CurrentHP, Character.MaxHP);
    }
}