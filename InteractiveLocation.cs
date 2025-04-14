public class InteractiveLocation : Location
{
    private Location? teleport;
    public InteractiveLocation(int id) : base(id)
    {
    }

    public void setTeleport(InteractiveLocation teleport)
    {
        this.teleport = teleport;
    }

    public override void describe()
    {
        base.describe();
        Console.WriteLine("This room is interactive. To teleport type 'i'");
    }

    public override Location getNextLocation(string command)
    {
        var r = base.getNextLocation(command);
        if (string.Compare(command, "i") == 0)
        {
            if (teleport != null)
            {
                r = teleport;
            }
        }
        return r;
    }
}
