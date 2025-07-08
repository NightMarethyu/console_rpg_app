public class SceneManager
{
    Stack<IScene> scenes = new Stack<IScene>();

    public void PushScene(IScene scene)
    {
        scene.OnEnter();
        scenes.Push(scene);
    }

    public void PopScene()
    {
        scenes.Peek().OnExit();
        scenes.Pop();
    }

    public void Run()
    {
        bool game_running = true;
        while (game_running)
        {
            if (scenes.Count == 0)
                break;
            
            var transition = scenes.Peek().Run();
            
            if (transition != null)
            {
                switch (transition.action)
                {
                    case SceneAction.PUSH:
                        if (transition.nextScene != null)
                        {
                            PushScene(transition.nextScene);
                        }
                        break;
                    case SceneAction.POP:
                        PopScene();
                        break;
                    case SceneAction.CHANGE:
                        if (transition.nextScene != null)
                        {
                            PopScene();
                            PushScene(transition.nextScene);
                        }
                        break;
                    case SceneAction.EXIT_GAME:
                        game_running = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}