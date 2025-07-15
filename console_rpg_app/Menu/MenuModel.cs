public class MenuModel<T>
{
    public IReadOnlyList<MenuItem<T>> Items { get; }
    public int SelectedIndex { get; private set; }

    public MenuModel(List<MenuItem<T>> items)
    {
        Items = items;
    }

    public void MoveUp()
    {
        SelectedIndex = (SelectedIndex == 0) ? Items.Count - 1 : SelectedIndex - 1;
    }

    public void MoveDown()
    {
        SelectedIndex = (SelectedIndex + 1) % Items.Count;
    }
}