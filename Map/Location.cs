public class Location
{
    public string Name { get; protected set; }
    public List<Location> Exits = new List<Location>();
    private List<Character> Characters = new List<Character>();
    //private Invetory Inventory; TODO Implement Inventory

}
