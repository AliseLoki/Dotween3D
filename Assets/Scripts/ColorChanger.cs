using DG.Tweening;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _material;

    private Color _targetColor = Color.magenta;
    private float _duration = 2f;

    private void Start()
    {
        _material.DOColor(_targetColor, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
