using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveActivator : MonoBehaviour
{
    [SerializeField] private Point[] _pointsConteiners;

    private int _index = 0;

    public event UnityAction<Point> OnPlayerCanMove;

    private void Start()
    {
        foreach (var point in _pointsConteiners)
        {
            point.OnCanMove += SendEventPlayerCanMove;
        }
    }

    private void SendEventPlayerCanMove()
    {
        OnPlayerCanMove?.Invoke(_pointsConteiners[_index]);
        _index++;
    }

}
