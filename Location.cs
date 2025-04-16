public class Location
{
    private string name;
    private int id;
    private List<Location> connected;
    private List<Character> characters;

    public Location(int id)
    {
        this.id = id;
        name = "" + id;
        connected = new List<Location>();
        characters = new List<Character>();
    }

    public void AddLocation(Location location)
    {
        connected.Add(location);
        location.connected.Add(this);
    }

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }

    public virtual void Describe()
    {
        Console.WriteLine("You are currently at location " + name);
        if (connected.Count > 0)
        {
            Console.WriteLine("There are paths connected to the following locations: ");
            foreach (Location location in connected)
            {
                Console.WriteLine(location.name);
            }
        }
        if (characters.Count > 0)
        {
            Console.WriteLine("This area contains the following:");
            foreach (Character character in characters)
            {
                Console.WriteLine(character.Describe());
            }
        }
        
    }

    public virtual Location GetNextLocation(string command)
    {
        Location cur = this;
        foreach (Location location in connected)
        {
            if (location.name == command)
            {
                cur = location;
            }
        }
        return cur;
    }

    public bool HasConnected() { return connected.Count > 0; }
}
