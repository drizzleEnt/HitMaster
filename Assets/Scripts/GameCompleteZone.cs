using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameCompleteZone : MonoBehaviour
{
    public event UnityAction OnGameEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            OnGameEnd?.Invoke();
    }
}
