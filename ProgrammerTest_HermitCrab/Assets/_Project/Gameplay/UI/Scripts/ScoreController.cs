using System;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private ScoreUI _view;

    public Action OnDefeatAllEnemies;

    public int TotalEnemiesCount { get; private set; }
    public int EnemiesDefeated { get; private set; }

    private void Awake()
    {
        _view = GetComponent<ScoreUI>();

        DataEvent.DataEvent.Register<OnEnemySpawnEvent>(OnEnemySpawn);
        DataEvent.DataEvent.Register<OnEnemyDefeatEvent>(OnEnemyDefeat);
    }

    private void OnDestroy()
    {
        DataEvent.DataEvent.Unregister<OnEnemySpawnEvent>(OnEnemySpawn);
        DataEvent.DataEvent.Unregister<OnEnemyDefeatEvent>(OnEnemyDefeat);
    }

    private void OnEnemySpawn(OnEnemySpawnEvent eventData)
    {
        TotalEnemiesCount += eventData.amount;
        _view.DisplayScore(TotalEnemiesCount, EnemiesDefeated);
    }

    private void OnEnemyDefeat(OnEnemyDefeatEvent eventData)
    {
        EnemiesDefeated += eventData.amount;
        _view.DisplayScore(TotalEnemiesCount, EnemiesDefeated);

        if (EnemiesDefeated == TotalEnemiesCount)
        {
            OnDefeatAllEnemies?.Invoke();
        }
    }
}
