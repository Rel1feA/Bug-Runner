using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlackPanel : BasePanel
{
    [SerializeField]
    private float duration;

    private RectTransform rectTransform;
    private float screenCenterX = 0;
    private float offScreenLeft;
    private float offScreenRight;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        offScreenRight=Screen.width/2+rectTransform.rect.width/2;
        offScreenLeft=-offScreenRight;
        MoveIn();
    }

    public void MoveIn()
    {
        rectTransform.DOAnchorPosX(screenCenterX, duration).From(new Vector3(offScreenLeft,0,0));
    }

    public void MoveOut()
    {
        rectTransform.DOAnchorPosX(offScreenRight, duration).From(new Vector3(screenCenterX, 0, 0));
    }
}
