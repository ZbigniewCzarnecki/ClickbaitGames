using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        WaitingToStart,
        Gameplay,
        Win
    }
    
    private GameState _gameState = GameState.WaitingToStart;
    
    private void Awake()
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
    }
}
