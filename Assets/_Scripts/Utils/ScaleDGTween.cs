using UnityEngine;
using DG.Tweening;

public class ScaleDGTween : MonoBehaviour
{
    [SerializeField] private float _scaleEndValue = 1.2f;
    [SerializeField] private float _duration = 1f;
    
    void Start()
    {
        transform.DOScaleX(_scaleEndValue, _duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
        
        transform.DOScaleZ(_scaleEndValue, _duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
