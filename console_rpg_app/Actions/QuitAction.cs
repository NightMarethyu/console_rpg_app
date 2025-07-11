public class QuitAction : IGameAction
{
    public string Description => "Quit Game";

    public SceneTransition? Execute()
    {
        return new SceneTransition(SceneAction.EXIT_GAME, null);
    }
}