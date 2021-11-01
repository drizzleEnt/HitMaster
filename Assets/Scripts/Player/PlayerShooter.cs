using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerInputReader
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;


    private void OnEnable()
    {
        OnShoot += Shoot;
    }

    private void OnDisable()
    {
        OnShoot -= Shoot;
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = ray.GetPoint(10) - _shootPoint.position;
        Bullet newBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        newBullet.Init(direction.normalized);

    }
}
