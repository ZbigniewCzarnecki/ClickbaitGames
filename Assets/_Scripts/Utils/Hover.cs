using System;
using UnityEngine;
using DG.Tweening;

public class Hover : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;

    private void OnDestroy()
    {
        transform.DOKill();
    }

    void Start()
    {
        if (transform == null)
        {
            return;
        }
        
        transform.DORotate(new Vector3(0, 360, 0), _duration, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
        
        transform.DOMoveY(transform.position.y + 1, _duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
