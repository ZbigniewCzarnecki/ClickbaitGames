using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<ISpawnable> _objectsToSpawn = new List<ISpawnable>();
    
    public void SpawnRandomObject(Transform spawnPoint)
    {
        int randomIndex = Random.Range(0, _objectsToSpawn.Count);
        //Instantiate(_objectsToSpawn[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
