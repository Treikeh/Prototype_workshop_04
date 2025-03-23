using System;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static event Action<GameState> OnGameStateChanged;

    public static GameManger instance;
    public GameState gameState;
    public int gold = 50;
    public int lives = 3;
    public int wave = 0;

    private void Awake()
    {
        // Set active game manager instance
        if (instance == null) {instance = this;}
        else {Destroy(gameObject);}

        // Initialize first game state
        ChangeState(GameState.Building);
    }

    private void Update()
    {
        if (lives <= 0 && gameState == GameState.Wave)
        {
            ChangeState(GameState.Lose);
        }
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        OnGameStateChanged?.Invoke(newState);
    }

    public void ResetGame()
    {
        gold = 50;
        lives = 50;
        wave = 0;
        ChangeState(GameState.Building);
    }
}

public enum GameState
{
    Building,
    Wave,
    Lose,
}
