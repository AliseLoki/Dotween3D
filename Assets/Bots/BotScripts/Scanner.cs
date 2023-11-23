using UnityEngine;
using UnityEngine.Events;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _rotationAngle = 40f;
    [SerializeField] private float _scanDistance = 40f;
    [SerializeField] private LayerMask _layerMask;

    public event UnityAction<Transform> ResourceWasFound;

    private void Update()
    {
        CheckArea();
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, _rotationAngle * Time.deltaTime, 0);
    }

    private void CheckArea()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo,
             _scanDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            ResourceWasFound?.Invoke(hitInfo.collider.gameObject.transform);
        }
    }
}
