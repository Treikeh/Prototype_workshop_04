using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 25f;
    public float speed = 10f;
    public float lifetime = 5f;

    private void Start()
    {
        // Launch projectile
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>())
        {
            // Deal damage to enemy
            Health health = other.GetComponent<Health>();
            health.TakeDamage(damage);
            // Destroy projectile
            Destroy(gameObject);
        }
    }
}