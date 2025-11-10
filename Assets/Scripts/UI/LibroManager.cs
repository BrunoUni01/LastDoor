using UnityEngine;

public class LibroManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject libro;
    [Header("Pantallas del libro")]
    [SerializeField] GameObject[] PantallaCinematica;
    [SerializeField] GameObject[] PantallaPuzzles;
    [SerializeField] GameObject[] PantallaTrampas;
    [SerializeField] GameObject[] PantallaObjetos;
    [Header("Paginas por pantalla")]
    [SerializeField] GameObject[] pagCinematica;
    [SerializeField] GameObject[] pagPuzzles;
    [SerializeField] GameObject[] pagTrampas;
    [SerializeField] GameObject[] pagObjetos;
    private int pagCine;
    private int pagPuzle;
    private int pagTramp;
    private int pagObj;

    private void Awake()
    {
        pagCine = 0;
        pagPuzle = 0;
        pagTramp = 0;   
        pagObj = 0;
    }
    public void EntrarLibro()
    {
        libro.SetActive(!libro.activeSelf);
    }
    public void EntrarPantallaCinematica() 
    {
        PantallaCinematica[0].SetActive(!PantallaCinematica[0].activeSelf);
        PantallaCinematica[1].SetActive(!PantallaCinematica[1].activeSelf);
    }
    public void EntrarPantallaPuzzles()
    {
        PantallaPuzzles[0].SetActive(!PantallaPuzzles[0].activeSelf);
        PantallaPuzzles[1].SetActive(!PantallaPuzzles[1].activeSelf);
    }
    public void EntrarPantallaTrampas()
    {
        PantallaTrampas[0].SetActive(!PantallaTrampas[0].activeSelf);
        PantallaTrampas[1].SetActive(!PantallaTrampas[1].activeSelf);
    }
    public void EntrarPantallaObjetos()
    {
        PantallaObjetos[0].SetActive(!PantallaObjetos[0].activeSelf);
        PantallaObjetos[1].SetActive(!PantallaObjetos[1].activeSelf);
    }
    public void PasarDePagina(int cambio) 
    {
        if (cambio == -1)
        {
            if (PantallaCinematica[0].activeSelf)
            {
                pagCinematica[pagCine].SetActive(false);
                pagCinematica[pagCine + 1].SetActive(false);
                pagCine -= 2;
                pagCine = Mathf.Clamp(pagCine, 0, pagCinematica.Length - 1);
                pagCinematica[pagCine].SetActive(true);
                pagCinematica[pagCine + 1].SetActive(true);
            }
            else if (PantallaPuzzles[0].activeSelf)
            {
                pagPuzzles[pagCine].SetActive(false);
                pagPuzzles[pagCine + 1].SetActive(false);
                pagPuzle -= 2;
                pagPuzle = Mathf.Clamp(pagPuzle, 0, pagPuzzles.Length - 1);
                pagPuzzles[pagCine].SetActive(true);
                pagPuzzles[pagCine + 1].SetActive(true);
            }
            else if (PantallaTrampas[0].activeSelf)
            {
                pagTrampas[pagCine].SetActive(false);
                pagTrampas[pagCine + 1].SetActive(false);
                pagTramp -= 2;
                pagTramp = Mathf.Clamp(pagTramp, 0, pagTrampas.Length - 1);
                pagTrampas[pagCine].SetActive(true);
                pagTrampas[pagCine + 1].SetActive(true);
            }
            else if (PantallaObjetos[0].activeSelf)
            {
                pagObjetos[pagCine].SetActive(false);
                pagObjetos[pagCine + 1].SetActive(false);
                pagObj -= 2;
                pagObj = Mathf.Clamp(pagObj, 0, pagObjetos.Length - 1);
                pagObjetos[pagCine].SetActive(true);
                pagObjetos[pagCine + 1].SetActive(true);
            }
        }
        else if(cambio == 1)
        {
            if (PantallaCinematica[0].activeSelf)
            {
                pagCinematica[pagCine].SetActive(false);
                pagCinematica[pagCine + 1].SetActive(false);
                pagCine += 2;
                pagCine = Mathf.Clamp(pagCine, 0, pagCinematica.Length - 1);
                pagCinematica[pagCine].SetActive(true);
                pagCinematica[pagCine + 1].SetActive(true);
            }
            else if (PantallaPuzzles[0].activeSelf)
            {
                pagPuzzles[pagCine].SetActive(false);
                pagPuzzles[pagCine + 1].SetActive(false);
                pagPuzle += 2;
                pagPuzle = Mathf.Clamp(pagPuzle, 0, pagPuzzles.Length - 1);
                pagPuzzles[pagCine].SetActive(true);
                pagPuzzles[pagCine + 1].SetActive(true);
            }
            else if (PantallaTrampas[0].activeSelf)
            {
                pagTrampas[pagCine].SetActive(false);
                pagTrampas[pagCine + 1].SetActive(false);
                pagTramp += 2;
                pagTramp = Mathf.Clamp(pagTramp, 0, pagTrampas.Length - 1);
                pagTrampas[pagCine].SetActive(true);
                pagTrampas[pagCine + 1].SetActive(true);
            }
            else if (PantallaObjetos[0].activeSelf)
            {
                pagObjetos[pagCine].SetActive(false);
                pagObjetos[pagCine + 1].SetActive(false);
                pagObj += 2;
                pagObj = Mathf.Clamp(pagObj, 0, pagObjetos.Length - 1);
                pagObjetos[pagCine].SetActive(true);
                pagObjetos[pagCine + 1].SetActive(true);
            }
        }

    }
    private void Update()
    {
        
    }
}
