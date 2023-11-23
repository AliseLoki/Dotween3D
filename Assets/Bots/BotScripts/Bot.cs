using System.Collections;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private bool _isBusy = false;
    [SerializeField] private bool _isTakenResource = false;
    [SerializeField] private Base _base;

    private Transform _startPosition;
    private Coroutine _targetMoving;

    public bool IsTakenResource => _isTakenResource;
    public bool IsBusy => _isBusy;

    private void Awake()
    {
        _startPosition = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Resource resource))
        {
            if (_isTakenResource == false)
            {
                TakeResource(resource.gameObject.GetComponent<Transform>());
                ReturnToBase(_base.transform);
                resource.transform.SetParent(null);
            }
        }
    }

    public void PutResource()
    {
        if (_targetMoving != null)
        {
            StopCoroutine(_targetMoving);
        }

        _isBusy = false;
        _isTakenResource = false;
        transform.position = _startPosition.position;
    }

    public void MoveToTarget(Transform target)
    {
        _targetMoving = StartCoroutine(Moving(target));
    }

    private void TakeResource(Transform resource)
    {
        if (_targetMoving != null)
        {
            StopCoroutine(_targetMoving);
        }

        resource.gameObject.SetActive(false);
        resource.SetParent(transform);
        _isTakenResource = true;
    }

    private void ReturnToBase(Transform startPoint)
    {
        _targetMoving = StartCoroutine(Moving(startPoint));
    }

    private void Move(Transform targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
    }

    private IEnumerator Moving(Transform target)
    {
        while (transform.position != target.position)
        {
            Move(target);
            _isBusy = true;
            yield return null;
        }
    }
}
