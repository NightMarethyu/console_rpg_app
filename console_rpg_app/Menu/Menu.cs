public class Menu
{
    public IReadOnlyList<IGameAction> Actions { get; }
    public int SelectedIndex { get; private set; }

    public Menu(List<IGameAction> actions)
    {
        Actions = actions;
    }

    public void MoveUp()
    {
        SelectedIndex = (SelectedIndex == 0) ? Actions.Count - 1 : SelectedIndex - 1;
    }

    public void MoveDown()
    {
        SelectedIndex = (SelectedIndex + 1) % Actions.Count;
    }

    public SceneTransition? Select()
    {
        return Actions[SelectedIndex].Execute();
    }
}