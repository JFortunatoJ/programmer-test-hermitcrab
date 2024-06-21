using System;
using UnityEngine;

public abstract class BaseCharacterHealth : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _maxHealth;

    private int _health;

    public int Health
    {
        get => _health;
        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            if (_health == 0)
            {
                Destroy();
            }
        }
    }
    public int MaxHealth => _maxHealth;

    protected Action OnDie;

    public void Init(Action onDie)
    {
        OnDie = onDie;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
    }

    public void Destroy()
    {
        OnDie?.Invoke();
    }
}
