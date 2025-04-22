using System;
using System.ComponentModel.Design;

public static class Parser
{

    public static void Parse(Player player, Location location, string com)
	{
		string[] coms = com.ToLower().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
		if (coms.Length == 0)
			throw new ArgumentException(com);

		foreach (Command command in CommandManager.Commands)
        {
            if (command.Name == coms[0])
            {
                command.Execute(player, location, coms);
                return;
            }
        }
    }
}
