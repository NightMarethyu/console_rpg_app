namespace OLD
{

    public static class SceneManager
    {
        public static Scene? currentScene
        {
            get; private set;
        }

        public static void SetScene(Scene newScene)
        {
            if (currentScene != null)
            {
                currentScene.Exit();
            }
            currentScene = newScene;
            currentScene.Enter();
        }

        public static void RunCurrentScene()
        {
            if (currentScene != null)
            {
                while (currentScene.IsRunning)
                {
                    currentScene.Run();
                }
            }
            else
            {
                Console.WriteLine(GameStrings.ErrorMsgs.NoScene);
            }
        }
    }
}