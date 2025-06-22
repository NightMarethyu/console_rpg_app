public class LocationBuilder
{
    private Guid _id;
    private string _name;
    private HashSet<string> _tags = new HashSet<string>();
    private HashSet<Guid> _exitIDs = new HashSet<Guid>();
    private HashSet<Guid> _characterIDs = new HashSet<Guid>();

    public LocationBuilder()
    {
        _id = Guid.NewGuid();
        _name = string.Empty;
    }

    public LocationBuilder Reset()
    {
        _id = Guid.NewGuid();
        _name = string.Empty;
        _tags.Clear();
        _exitIDs.Clear();
        _characterIDs.Clear();
        return this;
    }

    public LocationBuilder AddTag(string tag) 
    {
        _tags.Add(tag);
        return this;
    }
    public LocationBuilder AddExit(Guid id) 
    {
        _exitIDs.Add(id);
        return this;
    }

    public LocationBuilder AddCharacter(Guid id)
    {
        _characterIDs.Add(id);
        return this;
    }

    public LocationBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public LocationBuilder WithID(Guid id)
    {
        _id = id;
        return this;
    }

    public Location Build()
    {
        Location newLocation = new Location(_name, _id, _tags, _exitIDs, _characterIDs);
        this.Reset();
        return newLocation;
    }
}