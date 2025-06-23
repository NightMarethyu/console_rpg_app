using System.ComponentModel;

public class MoveActionTemplate : IActionTemplate
{
    private readonly Guid _destinationId;

    public MoveActionTemplate(Guid destinationId)
    {
        _destinationId = destinationId;
    }

    public IGameAction ToAction(GameContext context)
    {
        var description = context.MapManager.GetLocationDescription(_destinationId);
        return new MoveAction(context.MapManager, description, _destinationId);
    }
}