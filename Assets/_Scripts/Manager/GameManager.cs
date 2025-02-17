using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private static PlayerManager _playerManager;
    private static GroundSpawner _groundSpawner;
    
    public PlayerManager PlayerManager { get { return _playerManager; } }
    public GroundSpawner GroundSpawner { get { return _groundSpawner; } }
    
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
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
    }

    private void Start()
    {
        PlayerManager.SpawnAndSetupPlayer();
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
