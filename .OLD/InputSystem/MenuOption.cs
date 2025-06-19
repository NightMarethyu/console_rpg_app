public class MenuOption
{
    public string Label {  get; set; }
    public Action Action { get; set; }

    public MenuOption(string label, Action action)
    {
        Label = label;
        Action = action;
    }
}