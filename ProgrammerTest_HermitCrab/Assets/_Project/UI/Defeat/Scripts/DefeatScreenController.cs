using UnityEngine.SceneManagement;

public class DefeatScreenController : BaseScreenController<DefeatScreenView>
{
    public static void Show()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.DefeatScreen), LoadSceneMode.Additive);
    }

    private void Start()
    {
        _view.OnTryAgain += TryAgain;
        _view.OnExitMenu += MainMenu;
    }

    private void OnDestroy()
    {
        _view.OnTryAgain -= TryAgain;
        _view.OnExitMenu -= MainMenu;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.Gameplay));
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.MainMenu));
    }
}
