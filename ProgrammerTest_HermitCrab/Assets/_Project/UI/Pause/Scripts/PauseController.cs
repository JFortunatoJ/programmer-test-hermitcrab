using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PauseView))]
public class PauseController : MonoBehaviour
{
    private PauseView _view;

    public static void PauseGame()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.Pause), LoadSceneMode.Additive);
    }

    private void Start()
    {
        _view = GetComponent<PauseView>();
        _view.OnContinueClick = Continue;
        _view.OnExitClick = LoadMainMenu;

        Time.timeScale = 0f;
    }

    private void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.Pause));
    }

    private void LoadMainMenu()
    {

    }
}
