using UnityEngine;
using Unity.AI.Navigation;

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

        InstantiateGroundForTheFirstTime(3);
    }

    public void MoveGroundToNewPosition(Transform groundTransform)
    {
        SetNewSpawnLocation();
        Vector3 newGroundPos = new Vector3(groundTransform.position.x, groundTransform.position.y, _newZPos);
        groundTransform.position = newGroundPos;
        BuildNewNavMesh();
        
        Ground tmpGround = groundTransform.GetComponent<Ground>();
        UpdateSpawnPointManager(tmpGround);
    }

    private void InstantiateGroundForTheFirstTime(int howMany)
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
        Ground tmpGround = Instantiate(_groundPrefab,
            new Vector3(_groundPrefab.position.x, _groundPrefab.position.y, _groundPrefab.position.z + _newZPos),
            Quaternion.identity).GetComponent<Ground>();

        UpdateSpawnPointManager(tmpGround);
    }

    private void BuildNewNavMesh()
    {
        _navMeshSurface.BuildNavMesh();
    }

    private void UpdateSpawnPointManager(Ground ground)
    {
        foreach (Transform spawnPoint in ground.SpawnPointList)
        {
            GameManager.ObjectSpawner.SpawnRandomObject(spawnPoint);
            //GameManager.SpawnPointsManager.UpdateSpawnPoint(spawnPoint);
        }
    }
}