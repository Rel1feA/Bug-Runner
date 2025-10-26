using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FakeWall : MonoBehaviour
{
    [SerializeField]
    private float hideInterval;//精灵闪烁间隔
    [SerializeField]
    private float hideDuration;//精灵消失持续时间

    private TilemapRenderer tilemapRenderer ;
    private float timer;

    private void Awake()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >=hideInterval&&tilemapRenderer.enabled)
        {
            tilemapRenderer.enabled = false;
        }
        if(timer>hideDuration+hideInterval&&!tilemapRenderer.enabled)
        {
            tilemapRenderer.enabled = true;
            timer = 0;
        }
    }
}
