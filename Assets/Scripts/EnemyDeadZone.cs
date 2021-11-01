using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BodyPartCollisionListener bodyPart))
        {
            bodyPart.GetDie();
        }
    }
}
