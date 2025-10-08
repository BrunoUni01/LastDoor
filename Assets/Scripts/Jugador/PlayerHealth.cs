using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth = 10;
    private PlayerMovement player;
    [SerializeField] private GameManagerBotones gameOver;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        health = maxHealth;
        gameOver = FindAnyObjectByType<GameManagerBotones>();
    }

    public void TakeDamage(int amount)
    {
        if (player.inTouchable) return;
        health -= amount;
        if (health <= 0)
        {
            GameOver();
        }
        Mathf.Clamp(health, 0, maxHealth);
        
    }
    private void GameOver() 
    {
        gameOver.SceneName(3);
    }
}
