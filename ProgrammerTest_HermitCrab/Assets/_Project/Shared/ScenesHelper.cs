using System.Collections.Generic;

public static class ScenesHelper
{
    public enum GameScenes
    {
        MainMenu, Gameplay, Pause, GameOver
    }

    public static Dictionary<GameScenes, string> Scenes = new Dictionary<GameScenes, string>
    {
        { GameScenes.MainMenu, "MainMenuScene" },
        { GameScenes.Gameplay, "GameplayScene" },
        { GameScenes.Pause, "PauseScene" },
        { GameScenes.GameOver, "GameOverScene" }
    };

    public static string GetSceneName(GameScenes scene)
    {
        return Scenes[scene];
    }
}
