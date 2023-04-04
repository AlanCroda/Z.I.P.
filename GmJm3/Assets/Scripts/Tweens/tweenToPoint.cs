using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class tweenToPoint : MonoBehaviour
{
    private Vector2 startPosition;
    public Vector2 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    public void movePoint()
    {
        transform.DOLocalMove(endPosition, 1.0f).SetEase(Ease.Linear);
    }
}
