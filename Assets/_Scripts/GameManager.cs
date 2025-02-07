using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    
    public static GameManager Instance;
    
    private GroundSpawner _groundSpawner;
    
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
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
    }

    private void Start()
    {
        SpawnPlayer();
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
    
    public void SpawnPlayer()
    {
        Instantiate(_playerPrefab.transform, _playerPrefab.transform.position, Quaternion.identity);
    }
}
