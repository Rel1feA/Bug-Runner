using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    private float speed;
    private Vector2 dir;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb2d.MovePosition(rb2d.position+dir * speed * Time.fixedDeltaTime);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDir(Vector2 dir)
    {
        this.dir = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EventCenter.Instance.EventTrigger("BulletHitPlayer");
        }
        if(collision.CompareTag("DeadArea"))
        {
            PoolManager.Instance.PushObj("Bullet",gameObject);
        }
    }
}
