using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool enpausa;
    [SerializeField] private bool agarraLlave;
    public GameObject puzzle2;
    //[HideInInspector] public bool puzzleFinish;
    [SerializeField] private bool puzzleInteract;
    private PlayerHealth jugador;
    public GameObject objetoPermanente;
    public GameObject objetoNoPermanente;
    [SerializeField] float offset = 1.2f;
    [SerializeField] private GameObject objetoSuelo;
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
        if (agarraLlave && Input.GetKeyDown(KeyCode.E))
        {
            PickUpLlave();
        }
    }

    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        enpausa = true;
    }
    private void PickUpLlave()
    {
        if (objetoPermanente != null) 
        {
            Vector2 direction = new Vector2(Mathf.Sign(transform.localScale.x), Mathf.Sign(transform.localScale.y));
            objetoPermanente.transform.position = (Vector2)(transform.position) + (direction * offset);
        }
        objetoPermanente = objetoSuelo;
        objetoPermanente.gameObject.transform.position = new Vector2(9000, 9000);
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
        if (collision.CompareTag("Puzzle 2"))
        {
            puzzleInteract = true;
        }
        if (collision.CompareTag("Llave"))
        {
            agarraLlave = true;
            objetoSuelo = collision.gameObject;
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
        if (collision.CompareTag("Llave"))
        {
            agarraLlave = false;
            objetoSuelo = null;
            

        }


    }
}