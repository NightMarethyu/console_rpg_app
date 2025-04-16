using System;
using System.ComponentModel.Design;

public class Parser
{
	public Parser()
	{
	}

    public void Parse(Player player, Location location, string com)
	{
		string[] coms = com.ToLower().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
		if (coms.Length == 0)
			throw new ArgumentException(com);

        Console.WriteLine("\nParsing command: " + com);

		foreach (Command command in CommandManager.Commands)
        {
            Console.WriteLine("Comparing: " + command.Name + " " + coms[0]);
            if (command.Name == coms[0])
            {
                command.Execute(player, location, coms);
                return;
            }
        }
    }
}
