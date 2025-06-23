public class MoveAction : IGameAction
{
    public string Description { get; }
    private readonly MapManager _mapManager;
    private readonly Guid _destinationId;

    public MoveAction(MapManager mapManager, string description, Guid destinationId)
    {
        _mapManager = mapManager;
        Description = $"Move to {description}";
        _destinationId = destinationId;
    }

    public void Execute()
    {
        _mapManager.MovePlayerTo(_destinationId);
    }
}