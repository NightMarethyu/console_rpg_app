public class ConsoleRenderer
{
    public void Render(string headerText, Menu menu)
    {
        Console.Clear();
        Console.CursorVisible = false;

        Console.SetCursorPosition(0, 0);
        Console.WriteLine(headerText);

        int menuTopPosition = Console.CursorTop;

        for (int i = 0; i < menu.Actions.Count; i++)
        {
            Console.SetCursorPosition(0, menuTopPosition + i);
            bool isSelected = (i == menu.SelectedIndex);

            if (isSelected)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($"> {menu.Actions[i].Description}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {menu.Actions[i].Description}");
            }
        }
    }
}