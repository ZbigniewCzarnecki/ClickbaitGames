using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _targetPrefab;
    
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _targetForwardSpeed = 5f;
    [SerializeField] private float _targetHorizontalSpeed = 10f;

    private PlayerFollowTarget _playerTarget;
    private PlayerWeapon _playerWeapon;
    private Player _player;
    private Health _health;
    
    public Player Player => _player;
    public PlayerWeapon PlayerWeapon => _playerWeapon;
    public Health Health => _health;

    public void SpawnAndSetupPlayer()
    {
        SpawnPlayerTarget();
        SpawnPlayer();
    }

    private void SpawnPlayerTarget()
    {
        _playerTarget = Instantiate(_targetPrefab, transform.position, Quaternion.identity)
            .GetComponent<PlayerFollowTarget>();
        _playerTarget.Setup(_targetForwardSpeed, _targetHorizontalSpeed);
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(_playerPrefab, _playerPrefab.transform.position, Quaternion.identity).GetComponent<Player>();
        _player.SetupPlayer(_playerSpeed, _playerTarget.transform);
        _health = _player.GetComponent<Health>();

        _playerWeapon = _player.GetComponentInChildren<PlayerWeapon>();
        
        //Setup Camera Target
        CinemachineCameraFollow.Instance.SetTarget(_player.transform);
    }
}