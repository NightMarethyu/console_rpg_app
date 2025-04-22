public class TeleportLocation : Location
{
    public Location? teleport { get; private set; }
    public TeleportLocation(int id) : base(id)
    {
    }

    public void SetTeleport(TeleportLocation teleport)
    {
        this.teleport = teleport;
    }

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine(GameStrings.Teleport.TeleporterExists);
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

    public Location Teleport()
    {
        if (teleport == null)
        {
            throw new InvalidOperationException(GameStrings.ErrorMsgs.TeleportUnset);
        }
        return teleport;
    }
}
