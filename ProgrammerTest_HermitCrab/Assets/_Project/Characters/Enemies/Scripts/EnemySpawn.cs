using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;
    [SerializeField] private Transform[] _waypoints;

    public Transform[] Waypoints => _waypoints;

    private void Start()
    {
        _enemy.SetWaypoints(Waypoints);
        _enemy.StartPatrol();
    }
}
