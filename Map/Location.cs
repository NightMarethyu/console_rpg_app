public class Location
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    private List<Guid> ExitIDs = new List<Guid>();
    private List<Character> Characters = new List<Character>();
    //private Invetory Inventory; TODO Implement Inventory

    public Location()
    {
        Id = Guid.NewGuid();
        Name = string.Empty;
    }

    public Location(string Name)
    {
        Id = Guid.NewGuid();
        this.Name = Name;
    }

    public void AddCharacter(Character character)
    {
        if (!Characters.Contains(character)) Characters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        Characters.Remove(character);
    }

    public void AddExit(Guid exitID)
    {
        ExitIDs.Add(exitID);
    }
}
