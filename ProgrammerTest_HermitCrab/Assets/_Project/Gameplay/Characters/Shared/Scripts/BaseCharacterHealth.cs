using DG.Tweening;
using System;
using UnityEngine;

public abstract class BaseCharacterHealth : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _maxHealth;

    [SerializeField]
    protected int _health;

    protected SpriteRenderer _characterRenderer;
    protected Tweener _damageBlinkTween;
    protected int _originalLayer;

    public virtual int Health
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
    public Action OnDie { get; set; }

    public virtual void Init(Action onDie, SpriteRenderer characterRenderer)
    {
        OnDie += onDie;
        Health = MaxHealth;
        _characterRenderer = characterRenderer;
        _originalLayer = gameObject.layer;
    }

    public virtual void TakeDamage(int damage)
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

        if (Health > 0 && IsDead)
        {
            IsDead = false;
            gameObject.layer = transform.GetChild(0).gameObject.layer = _originalLayer;
        }
    }

    public virtual void Destroy()
    {
        IsDead = true;
        gameObject.layer = transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Dead");
        OnDie?.Invoke();
    }
}
