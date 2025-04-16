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

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine("This room is interactive. To teleport type 'i'");
    }

    public override Location GetNextLocation(string command)
    {
        var r = base.GetNextLocation(command);
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
