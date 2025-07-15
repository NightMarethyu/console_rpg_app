public class ConsoleViewRenderer : IViewRenderer
{
    public void Render<T>(List<IViewComponent> components, MenuModel<T> menu)
    {
        foreach (var component in components)
        {
            component.Render();
        }

        Console.WriteLine();

        Console.CursorVisible = false;
        for (int i = 0; i < menu.Items.Count; i++)
        {
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

    public void Clear() => Console.Clear();
}