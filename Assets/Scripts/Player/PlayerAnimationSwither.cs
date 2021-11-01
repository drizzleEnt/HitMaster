using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSwither : PlayerInputReader
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        OnShoot += PlayShootAnimation;
    }

    private void OnDisable()
    {
        OnShoot -= PlayShootAnimation;
    }

    private void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
    }

    public void PlayDieAnimation()
    {
        _animator.SetBool("IsDead", true);
    }
}
