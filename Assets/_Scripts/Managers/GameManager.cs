using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private static PlayerManager _playerManager;
    //private static ActionSpawner _actionSpawner;
    private static GroundSpawner _groundSpawner;
    private static SpawnPointsManager _spawnPointsManager;
    private static ObjectSpawner _objectSpawner;
    
    public static PlayerManager PlayerManager { get { return _playerManager; } }
    //public static ActionSpawner ActionSpawner { get { return _actionSpawner; } }
    public static GroundSpawner GroundSpawner { get { return _groundSpawner; } }
    public static SpawnPointsManager SpawnPointsManager { get { return _spawnPointsManager; } }
    public static ObjectSpawner ObjectSpawner { get { return _objectSpawner; } }
    
    public enum GameState
    {
        WaitingForStart,
        Gameplay,
        Win
    }
    
    private GameState _gameState = GameState.WaitingForStart;
    
    private void Awake()
    {
        InitializeInstance();
        
        _playerManager = GetComponentInChildren<PlayerManager>();
        //_actionSpawner = GetComponentInChildren<ActionSpawner>();
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
        _spawnPointsManager = GetComponentInChildren<SpawnPointsManager>();
        _objectSpawner = GetComponentInChildren<ObjectSpawner>();
    }

    private void Start()
    {
        PlayerManager.SpawnAndSetupPlayer();
        //ActionSpawner.SetupSpawnPoints();
    }

    private void InitializeInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SetNewGameState(GameState gameState)
    {
        _gameState = gameState;
        OnGameStateChanged(_gameState);
    }

    private void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.WaitingForStart:
                break;
            case GameState.Gameplay:
                break;
            case GameState.Win:
                break;
        }
    }
}
