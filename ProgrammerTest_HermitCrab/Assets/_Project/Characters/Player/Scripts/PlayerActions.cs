using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : BaseCharacterActions<PlayerMovement, PlayerAnimations>
{
    [SerializeField] private PlayerBullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private int _bulletPoolSize = 10;

    private List<PlayerBullet> _bulletsPool;

    public override void Init(PlayerMovement movement, PlayerAnimations animations)
    {
        base.Init(movement, animations);
        InitializeBulletsPool();
    }

    private void InitializeBulletsPool()
    {
        _bulletsPool = new List<PlayerBullet>();
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            _bulletsPool.Add(InstantiateBullet());
        }
    }

    private PlayerBullet InstantiateBullet()
    {
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint);
        bullet.Init(_bulletSpawnPoint);
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    private PlayerBullet GetAvailableBulletFromPool()
    {
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            if (!_bulletsPool[i].isActiveAndEnabled) return _bulletsPool[i];
        }

        var newBullet = InstantiateBullet();
        _bulletsPool.Add(newBullet);

        return newBullet;
    }

    private void ShootBullet()
    {
        var bullet = GetAvailableBulletFromPool();
        bullet.gameObject.SetActive(true);
        bullet.Spawn(_movement.HorizontalDirection);
    }

    public override void MeleeAttack()
    {
        _animations.MeleeAttack();
    }

    public void Shoot()
    {
        _animations.Shoot();
        ShootBullet();
    }
}
