using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform[] _points;
    [SerializeField] private bool _isFirstPoint = false;

    public event UnityAction OnCanMove;

    private void Start()
    {
        
        foreach (var enemy in _enemies)
        {
            enemy.OnDead += DeleteEnemy;
        }

        if(_isFirstPoint)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Move();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            foreach (var enemy in _enemies)
            {
                enemy.Move();
            }
        }
    }

    private void DeleteEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.OnDead -= DeleteEnemy;
        if (_enemies.Count < 1)
            OnCanMove?.Invoke();
    }

    public Transform[] GetPoints()
    {
        return _points;
    }
}
