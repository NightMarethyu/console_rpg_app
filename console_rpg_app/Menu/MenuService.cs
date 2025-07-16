public class MenuService
{
    private readonly IViewRenderer _renderer;
    private readonly IUserInput _userInput;

    public MenuService(IViewRenderer renderer, IUserInput userInput)
    {
        _renderer = renderer;
        _userInput = userInput;
    }

    public T DisplayViewAndGetChoice<T>(List<IViewComponent> components, List<MenuItem<T>> items)
    {
        _renderer.Clear();
        var menuModel = new MenuModel<T>(items);
        int cursorTopPosition = _renderer.RenderComponents(components);

        while (true)
        {
            //_renderer.Render(components, menuModel);
            _renderer.RenderMenu(menuModel, cursorTopPosition);
            var key = _userInput.GetKey();

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    menuModel.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    menuModel.MoveDown();
                    break;
                case ConsoleKey.Enter:
                    _renderer.Clear();
                    return menuModel.Items[menuModel.SelectedIndex].Value;
            }
        }
    }
}