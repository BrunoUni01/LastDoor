using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] int damage = 2;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
