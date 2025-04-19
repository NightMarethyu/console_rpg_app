public abstract class Scene
{
    public bool IsRunning { get; set; } = true;
    public Scene NextScene { get; private set; }

    public virtual string SceneName => GetType().Name;

    public abstract void Run();

    public virtual void Enter()
    {
        Console.WriteLine("Entering scene...");
    }

    public virtual void Exit()
    {
        Console.WriteLine("Exiting scene...");
        IsRunning = false;
    }
}