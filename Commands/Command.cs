using System;

public abstract class Command
{
	public string Name;
	public string Description;


	public Command()
	{
	}

	public abstract void Execute(string[] args);
}
