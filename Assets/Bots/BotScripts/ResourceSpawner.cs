using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnPositionX;
    [SerializeField] private float _spawnPositionZ;
    [SerializeField] private float _spawnPositionY = 0.5f;

    [SerializeField] private int _maxResource = 5;

    [SerializeField] private Resource _resource;
    [SerializeField] private List<Resource> _resources = new List<Resource>();

    private void Update()
    {
        if (_resources.Count < _maxResource)
        {
            SpawnResource();
        }
    }

    private void SpawnResource()
    {
        Vector3 spawnPos = new Vector3(Random.Range(_spawnPositionX, -_spawnPositionX),
            _spawnPositionY, Random.Range(_spawnPositionZ, -_spawnPositionZ));

        Instantiate(_resource, spawnPos, Quaternion.identity);
        _resources.Add(_resource);
    }
}
