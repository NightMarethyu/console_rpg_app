public class ConsoleViewRenderer : IViewRenderer
{
    public void Render<T>(List<IViewComponent> components, MenuModel<T> menu)
    {
        Clear(); // This works, but it introduces flickering that I don't want

        foreach (var component in components)
        {
            component.Render();
        }

        Console.WriteLine();

        
    }

    public void Clear() => Console.Clear();

    public int RenderComponents(List<IViewComponent> components)
    {
        foreach (var component in components)
        {
            component.Render();
        }
        Console.WriteLine();
        return Console.GetCursorPosition().Top;
    }

    public void RenderMenu<T>(MenuModel<T> menu, int cursorTopPosition = 0)
    {
        Console.CursorVisible = false;
        for (int i = 0; i < menu.Items.Count; i++)
        {
            Console.SetCursorPosition(0, cursorTopPosition + i);
            bool isSelected = (i == menu.SelectedIndex);
            if (isSelected)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"> {menu.Items[i].DisplayName}");
            Console.ResetColor();
        }
    }
}