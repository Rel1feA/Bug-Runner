using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : MonoBehaviour
{
    [SerializeField]
    private float hideInterval;//精灵闪烁间隔
    [SerializeField]
    private float hideDuration;//精灵消失持续时间

    private SpriteRenderer spriteRenderer;
    private float timer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >=hideInterval&&spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
        }
        if(timer>hideDuration+hideInterval&&!spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
            timer = 0;
        }
    }
}
