using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerSpawnPoint _playerSpawn;
    [SerializeField] private TimerController _timer;
    [SerializeField] private ScoreController _score;
    [Space]
    [SerializeField] private int _gameTimeInSeconds = 60;

    public bool GameOver { get; private set; }
    public bool IsPaused { get; set; }

    private void OnEnable()
    {
        DataEvent.DataEvent.Register<OnGamePauseEvent>(OnPauseGame);
    }

    private void OnDisable()
    {
        DataEvent.DataEvent.Unregister<OnGamePauseEvent>(OnPauseGame);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameOver = false;

        _timer.StartTimer(_gameTimeInSeconds, OnTimeOut);
        _score.OnDefeatAllEnemies = OnDefeatAllEnemies;

        _playerSpawn.SpawnPlayer();
    }

    private void OnTimeOut()
    {
        HandleGameOver(false);
    }

    private void OnDefeatAllEnemies()
    {
        HandleGameOver(true);
    }

    private void HandleGameOver(bool victory)
    {
        if (GameOver) return;

        GameOver = true;

        _timer.StopTimer();
        _playerSpawn.Player.Animations.Respawn();

        if (victory)
        {
            SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.VictoryScreen), LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(ScenesHelper.GetSceneName(ScenesHelper.GameScenes.DefeatScreen), LoadSceneMode.Additive);
        }
    }

    private void OnPauseGame(OnGamePauseEvent eventData)
    {
        Time.timeScale = eventData.isPaused ? 0 : 1;
        IsPaused = eventData.isPaused;

        if (IsPaused)
        {
            PauseController.Open();
        }
        else
        {
            PauseController.Close();
        }
    }
}
