using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvasRotator : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<Camera>().transform;
    }

    private void Update()
    {
        transform.DOLookAt(_target.position, 0.01f);
    }
}
