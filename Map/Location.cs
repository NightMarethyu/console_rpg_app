public class Location
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    private HashSet<Guid> ExitIDs = new HashSet<Guid>();
    private HashSet<Guid> CharacterIds = new HashSet<Guid>();
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

    public void AddCharacter(Character character) { CharacterIds.Add(character.Id); }

    public void RemoveCharacter(Character character) { CharacterIds.Remove(character.Id); }

    public IEnumerable<Guid> GetLocationCharacters() { return CharacterIds; }

    public IEnumerable<Guid> GetLocationExits() { return ExitIDs; }

    public void AddExit(Guid exitID) { ExitIDs.Add(exitID); }

    public void AddTag(string tag) { Tags.Add(tag); }
}
