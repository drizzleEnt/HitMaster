using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartCollisionListener : MonoBehaviour
{
    [SerializeField] private int _incomeDamage = 10;

    private Rigidbody _rigidbody;
    private Enemy _enemy;
    private RagdollSwitcher _switcher;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _switcher = GetComponentInParent<RagdollSwitcher>();
        _enemy = GetComponentInParent<Enemy>();
    }

    public void GetHitted(Bullet bullet)
    {
        _switcher.SwitchRagdoll();
        _enemy.ApplyDamage(_incomeDamage);
        Vector3 direction = (bullet.transform.position - transform.position);
        direction.y = Mathf.Abs(direction.y);
        direction.z = Mathf.Abs(direction.z);
        _rigidbody.AddForce(direction * 5000, ForceMode.Acceleration);
    }

    public void GetDie()
    {
        _enemy.ApplyDamage(100);
    }
}
