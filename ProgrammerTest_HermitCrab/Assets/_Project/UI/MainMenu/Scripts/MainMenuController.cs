using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MainMenuView))]
public class MainMenuController : MonoBehaviour
{
    private MainMenuView _view;

    private void Start()
    {
        _view = GetComponent<MainMenuView>();
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
