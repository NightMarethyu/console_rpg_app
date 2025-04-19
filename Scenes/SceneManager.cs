public static class SceneManager
{
    private static Scene currentScene;

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
            Console.WriteLine("No active scene");
        }
    }
}