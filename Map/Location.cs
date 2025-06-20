public class Location
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    private List<Guid> ExitIDs = new List<Guid>();
    private List<Character> Characters = new List<Character>();
    public HashSet<string> Tags { get; protected set; }
    //private Invetory Inventory; TODO Implement Inventory

    public Location()
    {
        Id = Guid.NewGuid();
        Name = string.Empty;
        Tags = new HashSet<string>();
    }

    public Location(string Name) : this()
    {
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

    public void AddTag(string tag)
    {
        Tags.Add(tag); 
    }
}
