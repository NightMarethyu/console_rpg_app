public interface IGameAction
{
    string Description { get; }
    SceneTransition? Execute();
}