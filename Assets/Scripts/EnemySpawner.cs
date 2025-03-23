using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    public Transform waypointsRoot;
    public List<GameObject> enemies;

    private float spawnTimer = 0f;
    private List<Transform> waypoints = new();

    private void Start()
    {
        // Get waypoints enemies will follow
        foreach (Transform child in waypointsRoot)
        {
            waypoints.Add(child);
        }
    }

    private void Update()
    {
        // Don't spawn any enemies when the game state isn't wave
        if (GameManger.instance.gameState != GameState.Wave) { return; }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        // Get random enemy from list
        int index = Random.Range(0, enemies.Count);
        GameObject enemy = enemies[index];

        // Set waypoint movement waypoints
        WaypointsMovement movement = enemy.GetComponent<WaypointsMovement>();
        movement.waypoints = waypoints;

        Instantiate(enemy, transform.position, transform.rotation);
    }
}
