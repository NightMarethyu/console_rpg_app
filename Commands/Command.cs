public enum CommandType
{
	Attack,
	Drop,
	Help,
	Look,
	Move,
	Open,
	Quit,
	Take,
	Teleport,
	Inventory,
	Talk,
	Use,
	Equip
}

public abstract class Command
{
	public abstract string Name { get; }
	public virtual List<string> Aliases => new() { Name };
	public abstract string Description { get; }
	public abstract string Usage { get; }
	public abstract CommandType Type { get; }
	public abstract bool IsValid(Player player);
	public virtual void Execute(Player player, string[] args)
	{
		if (!IsValid(player)) return;
	}
}
