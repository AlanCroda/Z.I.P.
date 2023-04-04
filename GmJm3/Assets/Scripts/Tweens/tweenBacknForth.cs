using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class tweenBacknForth : MonoBehaviour
{
    public Vector3 endPosition;
    public float moveDuration;
    public float pauseDuration;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        BackNForth();
    }

    void BackNForth()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(endPosition, moveDuration).SetEase(Ease.Linear));
        seq.AppendInterval(pauseDuration);
        seq.Append(transform.DOMove(startPosition, moveDuration).SetEase(Ease.Linear));
        seq.AppendInterval(pauseDuration);
        seq.SetLoops(-1, LoopType.Restart);

    }
}
