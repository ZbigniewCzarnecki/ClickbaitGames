using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private float _zombieSpeed;

    [SerializeField] private List<Transform> _spawnPointList;
    
    public void SpawnZombies()
    {
        foreach (Transform spawnPoint in _spawnPointList)
        {
            if (spawnPoint.gameObject.activeInHierarchy)
            {
                Zombie zombie = ObjectPoolManager.SpawnObject<Zombie>(_zombiePrefab.gameObject, transform.position,
                    Quaternion.identity, ObjectPoolManager.PoolType.Zombie);
                
                zombie.SetupZombie(_zombieSpeed);

                if (!zombie.Target)
                {
                    zombie.Target = GameManager.PlayerManager.Player.transform;
                }
            }
        }
    }
}