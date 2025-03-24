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
    public int maxWaveSpawns = 0;
    public int enemiesKilled = 0;

    private void Awake()
    {
        // Set active game manager instance
        if (instance == null) {instance = this;}
        else {Destroy(gameObject);}
    }

    private void Start()
    {
        // Initialize first game state
        ResetGame();
    }

    private void Update()
    {
        // Move to lose state if all lives are lost
        if (lives <= 0 && gameState == GameState.Wave)
        {
            ChangeState(GameState.Lose);
        }

        // Move to building state when all enemies are killed
        if (enemiesKilled >= maxWaveSpawns && gameState == GameState.Wave)
        {
            ChangeState(GameState.Building);
        }
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case GameState.Wave:
                wave += 1;
                enemiesKilled = 0;
                maxWaveSpawns = GetMaxWaveSpawns();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public void ResetGame()
    {
        gold = 50;
        lives = 3;
        wave = 0;
        ChangeState(GameState.Building);
    }

    public int GetMaxWaveSpawns()
    {
        return 10 + wave;
    }
}

public enum GameState
{
    Building,
    Wave,
    Lose,
}
