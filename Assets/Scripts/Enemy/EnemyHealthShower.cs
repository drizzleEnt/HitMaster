using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealthShower : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    private Enemy _thisEnemy;

    private void Start()
    {
        _thisEnemy = GetComponent<Enemy>();
        _thisEnemy.HealthChanged += ShowHealth;
    }

    private void OnDisable()
    {
        _thisEnemy.HealthChanged -= ShowHealth;
    }

    private void ShowHealth(int health, int maxHealth)
    {
        _healthSlider.value = (float)health / (float)maxHealth;
    }
}
