using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PauseView))]
public class PauseController : BaseScreenController<PauseView>
{
    public static void Open()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.Pause), LoadSceneMode.Additive);
    }

    public static void Close()
    {
        SceneManager.UnloadSceneAsync(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.Pause));
    }

    private void Start()
    {
        _view.OnContinueClick = Continue;
        _view.OnExitClick = LoadMainMenu;
    }

    private void Continue()
    {
        DataEvent.DataEvent.Notify(new OnGamePauseEvent(false));
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.MainMenu));
    }
}
