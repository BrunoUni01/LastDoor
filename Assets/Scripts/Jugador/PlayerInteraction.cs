using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool enpausa;
    public GameObject puzzle2;
    private bool puzzleInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuPausa.SetActive(false);
        puzzleInteract = false;
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Puzzle 2"))
        {
            puzzleInteract = true;
        }
    }
}
