using System.Collections;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float delayToRespawn;

    public PlayerController Player => _player;

    private void Start()
    {
        _player.Health.OnDie += RespawnPlayer;
    }

    private void OnDestroy()
    {
        _player.Health.OnDie -= RespawnPlayer;
    }

    public void SpawnPlayer()
    {
        _player.Spawn(transform.position);
    }

    private void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(delayToRespawn);

        if (GameManager.Instance.GameOver) yield break;

        _player.Spawn(transform.position);
    }
}
