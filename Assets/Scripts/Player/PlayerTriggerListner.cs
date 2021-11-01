using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerListner : MonoBehaviour
{
    private PlayerAnimationSwither _animationSwither;

    public event UnityAction OnGameEnd;

    private void Start()
    {
        _animationSwither = GetComponentInParent<PlayerAnimationSwither>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BodyPartCollisionListener bodyPart))
        {
            if (bodyPart.GetComponentInParent<Enemy>().IsDead)
                return;

            OnGameEnd?.Invoke();
            _animationSwither.PlayDieAnimation();
        }
    }
}
