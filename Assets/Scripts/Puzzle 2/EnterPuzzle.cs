using Unity.VisualScripting;
using UnityEngine;

public class EnterPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject puzzle2;
    private bool playerInteract;
    private bool playerKey;
    private PlayerMovement player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        playerInteract = false;
        playerKey = false;
    }
    void Puzzle2()
    {
        if (playerKey)
        {
            if (playerInteract)
            {
                puzzle2.SetActive(true);
                player.gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerKey = true;
        }
        else 
        {
            playerKey= false;
        }
        
        
    }
    private void FixedUpdate()
    {
        Puzzle2();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            playerInteract = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInteract = false;
        }
    }
}
