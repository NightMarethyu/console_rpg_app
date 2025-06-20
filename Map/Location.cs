public class Location
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public List<Guid> ExitIDs = new List<Guid>();
    private List<Character> Characters = new List<Character>();
    //private Invetory Inventory; TODO Implement Inventory

    public void AddCharacter(Character character)
    {
        if (!Characters.Contains(character)) Characters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        Characters.Remove(character);
    }
}
