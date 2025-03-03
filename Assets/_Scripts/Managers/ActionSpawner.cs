using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class ActionSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointsPrefab;
    [SerializeField] private float _spawnDistanceFromPlayer = 10f;
    [SerializeField] private List<Transform> _prefabsToSpawn = new List<Transform>();

    private Transform _playerTransform;
    private SpawnPoints _spawnPointsInstance;

    private bool _active = true;
    public bool Active { get { return _active; } set { _active = value; } }
    
    [SerializeField] private float _spawnInterval = 5f;
    private float _timer = 0f;
    
    public void SetupSpawnPoints()
    {
        _playerTransform = GameManager.PlayerManager.Player.transform;

        Vector3 spawnPosition = _playerTransform.position + Vector3.forward * _spawnDistanceFromPlayer;
        _spawnPointsInstance = Instantiate(_spawnPointsPrefab, spawnPosition, Quaternion.identity).GetComponent<SpawnPoints>();
    }

    private void Update()
    {
        if (_playerTransform && _spawnPointsInstance)
        {
            Vector3 newPos = new Vector3(0, 0, _playerTransform.position.z + _spawnDistanceFromPlayer);
            _spawnPointsInstance.transform.position = newPos;
        }

        if (_active)
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnInterval)
            {
                SpawnRandomObject();
                _timer = 0f;
            }
        }
    }
    
    private void SpawnRandomObject()
    {
        if (_prefabsToSpawn.Count == 0)
        {
            Debug.LogWarning("Lista prefabrykatów jest pusta!");
            return;
        }

        int randomIndexLeft = Random.Range(0, _prefabsToSpawn.Count);
        int randomIndexRight = Random.Range(0, _prefabsToSpawn.Count);
        Transform selectedPrefabLeft = _prefabsToSpawn[randomIndexLeft];
        Transform selectedPrefabRight = _prefabsToSpawn[randomIndexRight];

        Instantiate(selectedPrefabLeft, _spawnPointsInstance.spawnPointLeft.position, quaternion.identity);
        Instantiate(selectedPrefabRight, _spawnPointsInstance.spawnPointRight.position, quaternion.identity);
    }
}