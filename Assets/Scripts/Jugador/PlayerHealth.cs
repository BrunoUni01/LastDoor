using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth = 10;
    private PlayerMovement player;
    [SerializeField] private GameManagerBotones gameOver;
    [SerializeField] private GameObject text; 

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
        Invoke(nameof(MostrarTexto), 0.5f);
    }
    void MostrarTexto() 
    {
        text.SetActive(true);
        Invoke(nameof(OcultarTexto), 2f);
    }
    void OcultarTexto() 
    {
        text.SetActive(false);
    }
    private void GameOver() 
    {
        gameOver.SceneName(3);
    }
}
