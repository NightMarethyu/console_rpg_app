public class AttackActionTemplate : IActionTemplate
{
    private readonly Guid _targetId;

    public AttackActionTemplate(Guid targetId)
    {
        _targetId = targetId;
    }

    public IGameAction ToAction(GameContext context)
    {
        return new AttackAction(context.CharacterManager.PlayerID, _targetId, context.CharacterManager, context.MapManager, context.MenuService);
    }
}