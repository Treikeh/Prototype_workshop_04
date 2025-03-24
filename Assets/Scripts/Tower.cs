using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform muzzle;
    public GameObject projectilePrefab;

    private float shootTimer = 0f;
    private List<GameObject> enemies = new();


    private void Update()
    {
        // Check to see if there's any enemies in range
        if (enemies.Count > 0)
        {
            Vector3 enemyPos = enemies[0].transform.position;
            RotateTowardsPosition(enemyPos);
            shootTimer += Time.deltaTime;
            if (shootTimer >= fireRate)
            {
                Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
                shootTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemies.Contains(other.gameObject))
        {
            enemies.Remove(other.gameObject);
        }
    }

    private void RotateTowardsPosition(Vector3 position)
    {
        Vector3 vectorToTarget = position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = newRotation;
    }
}
