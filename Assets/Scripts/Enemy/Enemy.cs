using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    
    private RagdollSwitcher _switcher;
    private int _maxHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<Enemy> OnDead;

    public bool IsDead { get; private set; } = false;

    private void OnEnable()
    {
        _switcher = GetComponentInChildren<RagdollSwitcher>();
        _maxHealth = _health;
        //Move(player.transform);
    }

    public void Move()
    {
        _switcher.PlayRunAnimation();
        Player player = FindObjectOfType<Player>();
        Vector3 position = player.transform.position;
        position.y = transform.position.y;
        transform.DOMove(position, 10f);
    }

    public void ApplyDamage(int damage)
    {
        transform.DOKill();
        _health -= damage;
        HealthChanged?.Invoke(_health, _maxHealth);
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        IsDead = true;
        OnDead?.Invoke(this);
        enabled = false;
    }
}
