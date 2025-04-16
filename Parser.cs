using System;
using System.ComponentModel.Design;

public class Parser
{
	private string Command;
	private List<Command> Commands;

	public Parser(string com)
	{
		this.Command = com;
	}

	public void AddCommand(Command com)
    {
        if (com != null)
            Commands.Add(com);
        else
            throw new ArgumentException("Command cannot be null");
    }

    public void Parse(string com)
	{
        com.ToLower();
		string[] coms = Command.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
		if (coms.Length == 0)
			throw new ArgumentException(Command);

		foreach (Command com in Commands)
        {
            if (com.Name == coms[0])
            {
                com.Execute(coms);
                return;
            }
        }
    }
}
