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

    public void AddInventory()
    {
        Inventory = new Inventory();
    }

    public virtual void Describe()
    {
        Console.WriteLine(GameStrings.LocationMsgs.BaseDescribe, name);
        if (connected.Count > 0)
        {
            Console.WriteLine(GameStrings.LocationMsgs.ConnectedLocals);
            foreach (Location location in connected)
            {
                Console.WriteLine(location.name);
            }
        }
        if (characters.Count > 0)
        {
            Console.WriteLine(GameStrings.LocationMsgs.Characters);
            foreach (Character character in characters)
            {
                Console.WriteLine(character.Describe());
            }
        }
        if (Inventory != null)
        {
            Console.WriteLine(GameStrings.LocationMsgs.LocationItems);
            foreach (var item in Inventory.GetAllItems())
            {
                if (item is ContainerItem container)
                {
                    Console.WriteLine($"- {container.Describe()}");
                    
                    if (container.IsOpen)
                    {
                        Console.WriteLine(GameStrings.General.Contains);
                        container.Inventory.ListItems();
                    }
                }
                else
                {
                    Console.WriteLine($"- {item.Describe()}");
                }
            }
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
    public bool HasEnemies()
    {
        foreach (Character enemy in characters)
        {
            if (enemy is Enemy)
                return true;
        }
        return false;
    }

    public Enemy? FindFirstEnemy(string name)
    {
        foreach (Character enemy in characters)
        {
            if (enemy is Enemy && enemy.Name.ToLower() == name)
                return (Enemy)enemy;
        }
        Console.WriteLine(GameStrings.LocationMsgs.EnemyNotFound, name);
        return null;
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);
    }
}
