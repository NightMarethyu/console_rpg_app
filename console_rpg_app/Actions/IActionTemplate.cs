public interface IActionTemplate
{
    IGameAction ToAction(GameContext context);
}