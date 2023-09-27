using DG.Tweening;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    private float _point = 8f;
    private float _duration = 5f;

    private void Start()
    {
        transform.DOMoveZ(_point, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
