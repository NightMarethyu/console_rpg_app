public static class InputManager
{
    public static void RunMenu(List<MenuOption> options, string? prompt = null, List<string>? outputLines = null)
    {
        int index = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            if (outputLines != null)
            {
                foreach (string line in outputLines) 
                    Console.WriteLine(line);
                Console.WriteLine();
            }

            if (!string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine(prompt + "\n");
            }

            for (int i = 0; i < options.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(options[i].Label);
                Console.ResetColor();
            }
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                index = (index == 0) ? options.Count - 1 : index - 1;
            else if (key == ConsoleKey.DownArrow)
                index = (index + 1) % options.Count;
        } while (key != ConsoleKey.Enter);

        options[index].Action.Invoke();
    }
}