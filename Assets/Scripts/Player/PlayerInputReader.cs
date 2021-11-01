using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputReader : MonoBehaviour
{

    public event UnityAction OnShoot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }
}
