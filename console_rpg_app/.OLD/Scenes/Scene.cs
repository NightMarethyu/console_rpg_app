namespace OLD
{

    public abstract class Scene
    {
        public bool IsRunning { get; set; } = true;
        public Scene? NextScene
        {
            get; private set;
        }
        public Player player
        {
            get; protected set;
        }
        public List<string> Info
        {
            get; set;
        }

        public Scene(Player player)
        {
            this.player = player;
            this.Info = new List<string>();
        }

        public virtual string SceneName => GetType().Name;

        public abstract void Run();

        public virtual void Enter()
        {
            Console.WriteLine(GameStrings.SceneMsgs.EnterScene);
        }

        public virtual void Exit()
        {
            Console.WriteLine(GameStrings.SceneMsgs.ExitScene);
            IsRunning = false;
        }
    }
}