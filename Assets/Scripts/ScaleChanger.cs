using DG.Tweening;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    private float _maxScale = 1f;

    private void Start()
    {
        transform.DOScale(Vector3.one, _maxScale).SetLoops(-1, LoopType.Yoyo);
    }
}
