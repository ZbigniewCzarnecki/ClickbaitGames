using Unity.AI.Navigation;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Transform _groundPrefab;
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    private void Start()
    {
        float newZPos = 0;
        
        for (int i = 0; i <= 10; i++)
        {
            newZPos += _groundPrefab.localScale.z;
            
            Instantiate(_groundPrefab,
                new Vector3(_groundPrefab.position.x, _groundPrefab.position.y, _groundPrefab.position.z + newZPos),
                Quaternion.identity);
        }
        
        _navMeshSurface.BuildNavMesh();
        
        PlayerSpawner.Instance.SpawnPlayer();
    }
}
