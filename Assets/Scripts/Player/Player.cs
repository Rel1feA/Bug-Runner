using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement;

    private void OnEnable()
    {
        EventCenter.Instance.AddListener("BulletHitPlayer", Dead);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveListener("BulletHitPlayer", Dead);
    }

    public void Dead()
    {
        Debug.Log("Dead");
        GameManager.Instance.ReStartLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeadArea"))
        {
            Dead();
        }
    }
}
