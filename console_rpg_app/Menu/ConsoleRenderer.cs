public class ConsoleRenderer
{
    public void Render(Menu menu, int topPosition)
    {
        Console.CursorVisible = false;

        for (int i = 0; i < menu.Actions.Count; i++)
        {
            Console.SetCursorPosition(0, topPosition + i);
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