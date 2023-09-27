using DG.Tweening;
using UnityEngine;

public class AxisYRotater : MonoBehaviour
{
    private float _angle = 60f;
    private float _duration = 0.1f;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, _angle, 0), _duration).SetLoops(-1, LoopType.Restart);
    }
}
