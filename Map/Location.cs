public class Location
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    private HashSet<Guid> ExitIDs = new HashSet<Guid>();
    private HashSet<Guid> CharacterIds = new HashSet<Guid>();
    private HashSet<string> Tags = new HashSet<string>();
    //private Invetory Inventory; TODO Implement Inventory

    public Location(string name, Guid? id = null, IEnumerable<string> tags = null, IEnumerable<Guid> exitIDs = null, IEnumerable<Guid> characterIDs = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));

        if (tags != null)
        {
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }

        if (exitIDs != null)
        {
            foreach (var exitID in exitIDs)
            {
                ExitIDs.Add(exitID);
            }
        }

        if (characterIDs != null)
        {
            foreach (var characterID in characterIDs)
            {
                CharacterIds.Add(characterID);
            }
        }
    }

    public void AddCharacter(Character character) { CharacterIds.Add(character.Id); }

    public void RemoveCharacter(Character character) { CharacterIds.Remove(character.Id); }

    public IEnumerable<Guid> GetCharacterIDs() { return CharacterIds; }

    public IEnumerable<Guid> GetExitIDs() { return ExitIDs; }

    public void AddExit(Guid exitID) { ExitIDs.Add(exitID); }

    public void AddTag(string tag) { Tags.Add(tag); }
}
