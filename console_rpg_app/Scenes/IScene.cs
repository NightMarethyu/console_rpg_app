public interface IScene
{
    void OnEnter();
    SceneTransition Run();
    void OnExit();
}