using System;
using TMPro;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text livesText;
    public TMP_Text waveText;
    public GameObject buildingUi;
    public GameObject waveUi;
    public GameObject loseUi;

    public TowerSpawner towerSpawner;

    private void OnEnable()
    {
        GameManger.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameManger.OnGameStateChanged -= OnGameStateChanged;
    }

    private void Update()
    {
        // Update all ui text.
        // Since performance isn't a concern it's easier to do it here than to make a event system that checks when a vlue is updated
        goldText.text = "Gold: " + GameManger.instance.gold.ToString();
        livesText.text = "Lives: " + GameManger.instance.lives.ToString();
        waveText.text = "Wave: " + GameManger.instance.wave.ToString();
    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            // Show ui elements based on game state
            case GameState.Building:
                buildingUi.SetActive(true);
                waveUi.SetActive(false);
                loseUi.SetActive(false);
                break;
            case GameState.Wave:
                buildingUi.SetActive(false);
                waveUi.SetActive(true);
                loseUi.SetActive(false);
                break;
            case GameState.Lose:
                waveUi.SetActive(false);
                buildingUi.SetActive(false);
                loseUi.SetActive(true);
                break;
        }
    }

    public void StartWave()
    {
        GameManger.instance.ChangeState(GameState.Wave);
        GameManger.instance.wave += 1;
    }

    public void RestartGame()
    {
        // Destroy every active enemy
        DestroyObjectsWithTag("Enemy");

        // Destroy every active tower
        DestroyObjectsWithTag("Tower");

        GameManger.instance.ResetGame();
    }

    public void BuildTower()
    {
        towerSpawner.SpawnTower();
    }

    private void DestroyObjectsWithTag(String tag)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
        {
            Destroy(obj);
        }
    }
}