using DG.Tweening;
using System;
using UnityEngine;

public abstract class BaseCharacterHealth : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _maxHealth;

    [SerializeField]
    protected int _health;

    public int Health
    {
        get => _health;
        protected set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            if (_health == 0)
            {
                Destroy();
            }
        }
    }

    public int MaxHealth => _maxHealth;

    public bool IsDead { get; protected set; }

    protected Action OnDie;
    protected SpriteRenderer _characterRenderer;
    protected Tweener _damageBlinkTween;

    public void Init(Action onDie, SpriteRenderer characterRenderer)
    {
        OnDie = onDie;
        Health = MaxHealth;
        _characterRenderer = characterRenderer;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        Health -= damage;
        DamageEffect();
    }

    protected void DamageEffect()
    {
        if (_damageBlinkTween != null && _damageBlinkTween.IsPlaying())
        {
            _damageBlinkTween.Kill();
            _characterRenderer.color = Color.white;
        }

        _damageBlinkTween = _characterRenderer.DOColor(Color.red, .2f).SetEase(Ease.OutFlash).SetLoops(2, LoopType.Yoyo);
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
    }

    public void Destroy()
    {
        IsDead = true;
        OnDie?.Invoke();
    }
}
