using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public int killScore;

    private float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            GameManger.instance.gold += killScore;
            Destroy(gameObject);
        }
    }

}
