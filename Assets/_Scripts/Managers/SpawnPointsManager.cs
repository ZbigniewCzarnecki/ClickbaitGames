using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    private Dictionary<Transform, bool> _spawnPointsDictionary = new Dictionary<Transform, bool>();

    public void UpdateSpawnPoint(Transform spawnPoint)
    {
        if (_spawnPointsDictionary.TryAdd(spawnPoint, false))
        {
            //ObjectSpawner.SpawnRandomObject(spawnPoint);
        }
        else
        {
            SetSpawnPointAsNotOccupied(spawnPoint);
        }
    }

    public Transform GetEmptySpawnPoint()
    {
        foreach (var spawnPointKeyValuePair in _spawnPointsDictionary)
        {
            if (spawnPointKeyValuePair.Value == false)
            {
                SetSpawnPointAsOccupied(spawnPointKeyValuePair.Key);
                return spawnPointKeyValuePair.Key;
            }
        }

        return null;
    }

    private void SetSpawnPointAsOccupied(Transform spawnPoint)
    {
        _spawnPointsDictionary[spawnPoint] = true;
    }
    
    public void SetSpawnPointAsNotOccupied(Transform spawnPoint)
    {
        _spawnPointsDictionary[spawnPoint] = false;
    }
    
}
