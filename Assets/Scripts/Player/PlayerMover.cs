using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    private PlayerMoveActivator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<PlayerMoveActivator>();
        _activator.OnPlayerCanMove += Move;
    }

    private void OnDisable()
    {
        _activator.OnPlayerCanMove -= Move;
    }

    private void Move(Point pointsConteiner)
    {
        Transform[] points = pointsConteiner.GetPoints();
        Vector3[] positions = new Vector3[points.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = points[i].position;
        }

        transform.DOPath(positions, 10);
    }
}
