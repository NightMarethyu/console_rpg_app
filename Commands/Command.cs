using System;

public abstract class Command
{
	public abstract string Name { get; }
	public abstract string Description { get; }
	public abstract string Usage { get; }
	public abstract bool IsValid(Player player, Location location);
	public abstract void Execute(Player player, Location location, string[] args);
}
