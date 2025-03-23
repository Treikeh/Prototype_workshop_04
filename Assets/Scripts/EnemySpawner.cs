using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    public Transform waypointsRoot;
    public List<GameObject> enemies;

    private float spawnTimer = 0f;
    private List<Transform> waypoints = new();

    void Start()
    {
        GetWaypoints();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnRandomEnemy();
        }
    }

    void GetWaypoints()
    {
        foreach (Transform child in waypointsRoot)
        {
            waypoints.Add(child);
        }
    }

    void SpawnRandomEnemy()
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
