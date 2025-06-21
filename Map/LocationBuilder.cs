public class LocationBuilder
{
    private Location _location = new Location();

    public LocationBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._location = new Location();
    }

    public LocationBuilder AddTag(string tag) 
    {
        this._location.AddTag(tag);
        return this;
    }
    public LocationBuilder AddExit(Guid id) 
    {
        this._location.AddExit(id);
        return this;
    }

    public LocationBuilder WithName(string name)
    {
        // TODO
        return this; 
    }

    public Location Build()
    {
        Location res = this._location;
        this.Reset();
        return res;
    }
}