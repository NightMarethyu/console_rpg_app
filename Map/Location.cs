public class Location
{
    public string Name { get; protected set; }
    public List<Location> Exits = new List<Location>();
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
