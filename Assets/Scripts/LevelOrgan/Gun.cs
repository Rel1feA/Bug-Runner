using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Normal,
    Bug
}

[RequireComponent(typeof(Collider2D))]
public class Gun : MonoBehaviour
{
    [SerializeField]
    private float shootTime;//Éä»÷¼ä¸ôÊ±¼ä
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private BulletType bulletType;
    [SerializeField]
    private Bullet bullet;

    private void Update()
    {
        InvokeRepeating("Shoot", shootTime, shootTime);
    }

    public void Shoot()
    {
        Bullet b = Instantiate(bullet);
        Vector2 dir = new Vector2(transform.localScale.x, 0).normalized;
        b.SetSpeed(bulletSpeed);
        b.SetDir(dir);
    }
}
