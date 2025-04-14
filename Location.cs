public class Location
{
    private string name;
    private int id;
    private List<Location> connected;

    public Location(int id)
    {
        this.id = id;
        name = "" + id;
        connected = new List<Location>();
    }

    public void AddLocation(Location location)
    {
        connected.Add(location);
        location.connected.Add(this);
    }

    public virtual void describe()
    {
        Console.WriteLine("You are currently at location " + name);
        Console.WriteLine("There are paths connected to the following locations: ");
        foreach (Location location in connected)
        {
            Console.WriteLine(location.name);
        }
    }

    public virtual Location getNextLocation(string command)
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
}
