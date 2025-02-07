using Unity.AI.Navigation;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Transform _groundPrefab;
    private NavMeshSurface _navMeshSurface;
    
    private float _groundSizeZ;
    private float _newZPos;
    
    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _groundSizeZ = _groundPrefab.GetComponent<BoxCollider>().size.z;
        
        SpawnGround(2);
    }
    
    public void SpawnGround()
    {
        SetNewSpawnLocation();
        SpawnNewTile();
        BuildNewNavMesh();
    }

    private void SpawnGround(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            SetNewSpawnLocation();
            SpawnNewTile();
            BuildNewNavMesh();
        }
    }

    private void SetNewSpawnLocation()
    {
        _newZPos += _groundSizeZ;
    }

    private void SpawnNewTile()
    {
        Instantiate(_groundPrefab,
            new Vector3(_groundPrefab.position.x, _groundPrefab.position.y, _groundPrefab.position.z + _newZPos),
            Quaternion.identity);
    }
    
    private void BuildNewNavMesh()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
