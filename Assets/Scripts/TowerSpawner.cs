using System;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public BuildInfo tower;
    public void SpawnTower()
    {
        // Check to see if the player has enough gold to build a tower
        if (GameManger.instance.gold >= tower.cost)
        {
            Instantiate(tower.prefab, transform.position, transform.rotation);
            GameManger.instance.gold -= tower.cost;
        }
    }
}

[Serializable]
public class BuildInfo
{
    public GameObject prefab;
    public int cost;
}
