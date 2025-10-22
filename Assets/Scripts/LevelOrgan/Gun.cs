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
    private float bulletOffset;

    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > shootTime )
        {
            Shoot();
            timer= 0;
        }
    }

    public void Shoot()
    {
        string bulletName;
        switch (bulletType)
        {
            case BulletType.Normal:
                bulletName = "Bullet";
                break;
            case BulletType.Bug:
                bulletName = "FakeBullet";
                break;
            default:
                bulletName=string.Empty;
                break;
        }

        PoolManager.Instance.GetObj(bulletName, (obj) =>
        {
            Bullet b=obj.GetComponent<Bullet>();
            Vector2 dir = new Vector2(transform.localScale.x, 0).normalized;
            b.transform.position = transform.position + (Vector3)dir * bulletOffset;
            b.SetSpeed(bulletSpeed);
            b.SetDir(dir);
        });
    }
}
