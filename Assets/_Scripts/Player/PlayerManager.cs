using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _targetPrefab;
    
    [SerializeField] private float _moveSpeed = 10f;

    private PlayerFollowTarget _playerTarget;
    private Power _power;
    
    public Power Power => _power;

    public void SpawnAndSetupPlayer()
    {
        SpawnPlayerTarget();
        SpawnPlayer();
    }

    private void SpawnPlayerTarget()
    {
        _playerTarget = Instantiate(_targetPrefab, transform.position, Quaternion.identity)
            .GetComponent<PlayerFollowTarget>();
        _playerTarget.Setup(_moveSpeed);
    }

    private void SpawnPlayer()
    {
        Player player = Instantiate(_playerPrefab, _playerPrefab.transform.position, Quaternion.identity).GetComponent<Player>();
        player.SetupPlayer(_moveSpeed, _playerTarget.transform);
        _power = player.GetComponent<Power>();
        
        //Setup Camera Target
        CinemachineCameraFollow.Instance.SetTarget(player.transform);
    }
}