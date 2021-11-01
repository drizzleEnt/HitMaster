using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    [SerializeField]private Animator _animator;
    private bool _isRagdollActivated;
    private float _currentTime = 0;


    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
        //_animator = GetComponentInParent<Animator>();

        for (int i = 0; i < _rigidbodies.Count; i++)
        {
            _rigidbodies[i].isKinematic = true;
        }
        _isRagdollActivated = false;
    }
    //TODO: Switch Animation
    /*private void Update()
    {
        if (_isRagdollActivated == false)
            return;

        _currentTime += Time.deltaTime;
        if(_currentTime >= 3)
        {
            SwitchRagdoll();
            _isRagdollActivated = true;
        }

    }*/

    public void PlayRunAnimation()
    {
        _animator.enabled = true;
        _animator.SetBool("IsMoving", true);
    }

    public void SwitchRagdoll()
    {
        _animator.enabled = false;
        for (int i = 0; i < _rigidbodies.Count; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}
