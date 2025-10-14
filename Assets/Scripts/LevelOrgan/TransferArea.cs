using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TransferArea : MonoBehaviour
{
    [SerializeField]
    private Transform otherArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Vector3 playerPos=collision.transform.position;
            playerPos.x=otherArea.transform.position.x;
            collision.transform.position=playerPos;
        }
    }
}
