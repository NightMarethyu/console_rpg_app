public class QuitActionTemplate : IActionTemplate
{
    public IGameAction ToAction(GameContext context)
    {
        return new QuitAction();
    }
}