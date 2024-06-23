using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MainMenuView))]
public class MainMenuController : BaseScreenController<MainMenuView>
{
    private void Start()
    {
        Time.timeScale = 1;
        _view.OnPlayButtonClick += PlayGame;
    }

    private void OnDestroy()
    {
        _view.OnPlayButtonClick -= PlayGame;
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.Gameplay));
    }
}
