using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AutoDoor : MonoBehaviour
{
    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float waitTime;

    private Transform targetTra;
    private bool isWait;//判断是否到达目标点

    private void Start()
    {
        transform.position= startPos.position;
        targetTra= endPos;
        isWait = false;
    }

    private void Update()
    {
        CheckAndChangeTargetTra();
        if(!isWait)
        {
            Move(targetTra);
        }
    }

    public void Move(Transform targetTra)
    {
        Vector3 dir= (targetTra.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private IEnumerator IWait(float time)
    {
        isWait = true;
        yield return new WaitForSeconds(time);
        isWait = false;
    }

    public void CheckAndChangeTargetTra()
    {
        if(Vector3.Distance(transform.position,targetTra.position) < 0.05f)
        {
            if(targetTra==startPos)
            {
                targetTra = endPos;
            }
            else if(targetTra==endPos)
            {
                targetTra = startPos;
            }
            StartCoroutine(IWait(waitTime));
        }
    }
}
