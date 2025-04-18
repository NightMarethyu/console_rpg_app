public class Location
{
    private string name;
    private int id;
    private List<Location> connected;
    private List<Character> characters;
    public Inventory? Inventory { get; private set; }

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

    public void AddInventory(Inventory inventory)
    {
        Inventory = inventory;
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
        if (Inventory != null)
        {
            Console.WriteLine("This area contains the following items:");
            Inventory.ListItems();
        }
        Console.WriteLine();
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
    public bool HasEnemies() { return characters.Count >= 1; }

    public bool EnemyExists(string name)
    {
        return (characters.Any(character => character.Name.ToLower() == name));
    }

    public Enemy? FindFirstEnemy(string name)
    {
        foreach (Character enemy in characters)
        {
            if (enemy is Enemy && enemy.Name.ToLower() == name)
                return (Enemy)enemy;
        }
        Console.WriteLine("Enemy with name " + name + " not found in current location");
        return null;
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);
    }
}
