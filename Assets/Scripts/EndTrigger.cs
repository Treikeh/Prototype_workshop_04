using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GameManger.instance.lives -= 1;
            Destroy(other.gameObject);
        }
    }
}
