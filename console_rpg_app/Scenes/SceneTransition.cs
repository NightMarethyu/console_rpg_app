public record SceneTransition(
    SceneAction action,
    IScene? nextScene
);