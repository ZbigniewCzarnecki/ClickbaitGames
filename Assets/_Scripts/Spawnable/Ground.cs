using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointsParent;
    private List<Transform> _spawnPointList = new List<Transform>();
    public List<Transform> SpawnPointList { get { return _spawnPointList; } }

    private void Awake()
    {
        foreach (Transform spawnPoint in _spawnPointsParent)
        {
            _spawnPointList.Add(spawnPoint);
        }
    }
}
