public class Location
{
    public string name {  get; protected set; }
    private int id;
    public List<Location> connected { get; private set; }
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

    public virtual List<string> Describe()
    {
        List<string> result = new List<string>();

        string temp = string.Format(GameStrings.LocationMsgs.BaseDescribe, name);
        result.Add(temp);

        if (connected.Count > 0)
        {
            result.Add(GameStrings.LocationMsgs.ConnectedLocals);
            foreach (Location location in connected)
            {
                result.Add(location.name);
            }
        }
        if (characters.Count > 0)
        {
            result.Add(GameStrings.LocationMsgs.Characters);
            foreach (Character character in characters)
            {
                result.Add(character.Describe());
            }
        }
        if (Inventory != null)
        {
            result.Add(GameStrings.LocationMsgs.LocationItems);
            foreach (var item in Inventory.GetAllItems())
            {
                if (item is ContainerItem container)
                {
                    result.Add($"- {container.Describe()}");
                    
                    if (container.IsOpen)
                    {
                        result.Add(GameStrings.General.Contains);
                        result.AddRange(container.Inventory.ListItems());
                    }
                }
                else
                {
                    result.Add($"- {item.Describe()}");
                }
            }
        }
        return result;
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
