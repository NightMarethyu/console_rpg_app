public class ViewBuilder
{
    private readonly List<IViewComponent> _components = new();

    public ViewBuilder AddComponent(IViewComponent component)
    {
        _components.Add(component);
        return this;
    }

    public ViewBuilder AddText(string text) => AddComponent(new TextComponent(text));
    public ViewBuilder AddCharacterCombatStatus(Character character) => AddComponent(new CharacterCombatStatusComponent(character));

    public List<IViewComponent> Build() => new(_components);
}