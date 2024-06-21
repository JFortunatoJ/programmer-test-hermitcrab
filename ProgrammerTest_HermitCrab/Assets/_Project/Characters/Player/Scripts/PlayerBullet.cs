using UnityEngine;

public class PlayerBullet : MonoBehaviour, IWeapon
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _collisionRadius = .6f;
    [SerializeField] private LayerMask _collisionLayers;

    private Vector3 _movementDirection;
    private Transform _spawnPoint;

    public int Damage => _damage;

    public void Init(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
        _movementDirection = Vector3.zero;
    }

    public void Spawn(int directionX)
    {
        transform.position = _spawnPoint.position;
        transform.SetParent(null);

        _movementDirection.x = directionX;
        transform.rotation = _spawnPoint.rotation;

        Invoke(nameof(DestroyBullet), 3);
    }

    public void DestroyBullet()
    {
        transform.SetParent(_spawnPoint);
        transform.position = _spawnPoint.position;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Movement();
        CheckCollision();
    }

    private void Movement()
    {
        transform.position += _movementDirection * Time.deltaTime * 20f;
    }

    private void CheckCollision()
    {
        Collider2D[] collisions = new Collider2D[1];
        if (Physics2D.OverlapCircleNonAlloc(transform.position, _collisionRadius, collisions, _collisionLayers) > 0)
        {
            DestroyBullet();

            if (!collisions[0].TryGetComponent(out IDamageable damageable)) return;

            damageable.TakeDamage(Damage);
        }
    }
}
