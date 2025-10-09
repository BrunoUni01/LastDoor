using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool enpausa;
    public GameObject puzzle2;
    //[HideInInspector] public bool puzzleFinish;
    [SerializeField] private bool puzzleInteract;
    private PlayerHealth jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuPausa.SetActive(false);
        puzzleInteract = false;
        jugador = FindFirstObjectByType<PlayerHealth>();
        //puzzleFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enpausa)
            {
                Resumir();
            }
            else
            {
                Pausar();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Puzzle2();
        }
    }

    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        enpausa = true;
    }

    public void Resumir()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        enpausa = false;
    }

    void Puzzle2()
    {
        if (puzzleInteract)
        {
            puzzle2.SetActive(true);
            jugador.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Puzzle 2"))
        {
            puzzleInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish")) 
        {
            puzzleInteract = false;
        }
        if (collision.CompareTag("Puzzle 2"))
        {
            puzzleInteract = false;
        }
    }
}
