using System;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    public static event Action<GameState> OnGameStateChanged;

    public GameState gameState;
    public int gold;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ChangeState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Building:
                break;
            case GameState.Wave:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState {
    Building,
    Wave,

}
