using UnityEngine;
using DG.Tweening;  // Include DOTween namespace

public class CoinMotion : MonoBehaviour
{
    public float moveDistance = 0.5f;
    public float moveDuration = 1f;

    void Start()
    {
        transform.DORotate(new Vector3(0.0f, 360.0f, 0.0f), 5.0f, RotateMode.FastBeyond360)
                 .SetLoops(-1, LoopType.Restart)
                 .SetRelative()
                 .SetEase(Ease.Linear);        
    }
}
