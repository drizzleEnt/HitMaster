using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100;

    public void Init(Vector3 direction)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction * _speed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out BodyPartCollisionListener bodyPart))
        {
            bodyPart.GetHitted(this);
            Destroy(gameObject);
        }
    }
}
