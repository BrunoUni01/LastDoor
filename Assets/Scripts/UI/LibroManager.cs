using System.Collections;
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
    [SerializeField] GameObject[] TextosLibro;
    [SerializeField] private int pagCine;
    [SerializeField] private int pagPuzle;
    [SerializeField] private int pagTramp;
    [SerializeField] private int pagObj;
    [SerializeField] private string[] textosLibro = new string[] { "Trampa_Oso", "Trampa_Oso", "Trampa_Jaula", "Trampa_Jaula", "Puzzle_Escombros", "Puzzle_Escombros",
                                 "Puzzle_Palancas","Puzzle_Palancas", "Puzzle_Espejo","Puzzle_Espejo","Puzzle_Cajas","Puzzle_Cajas","Puzzle_Llaves","Puzzle_Llaves",
                                 "Puzzle_Puertas","Puzzle_Puertas","Puzzle_Laberinto","Puzzle_Laberinto"};

    [Header("EfectosBotoes")]

    [SerializeField] GameObject[] botones;

    [Header("Icono de nuevo descubrimiento")]
    [SerializeField] GameObject iconoDescubrimiento;
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
    public void DesbloquearEntrada(string id)
    {
        Debug.Log("Desbloqueando entrada en el libro: " + id);

        for (int i = 0; i < textosLibro.Length; i++) 
        {
            if (textosLibro[i] == id) 
            {
                TextosLibro[i].SetActive(true);
            }
        }

        //// Ejemplo de cómo podrías manejar distintos tipos
        //switch (id)
        //{
        //    case "Trampa_Oso":
        //        // Hacemos visible el texto o imagen de la trampa de oso
        //        // Supongamos que la página está en pagTrampas[0]
        //        if (TextosLibro.Length > 0)
        //            TextosLibro[0].SetActive(true);
        //        break;
        //    case "Trampa_Jaula":
        //        if (TextosLibro.Length > 1)
        //            TextosLibro[1].SetActive(true);
        //        break;
        //    case "Puzzle_Escombros":
        //        if (TextosLibro.Length > 2)
        //            TextosLibro[2].SetActive(true);
        //        break;
        //    case "Puzzle_Palancas":
        //        if (TextosLibro.Length > 3)
        //            TextosLibro[3].SetActive(true);
        //        break;
        //    case "Puzzle_Espejo":
        //        if (TextosLibro.Length > 4)
        //            TextosLibro[4].SetActive(true);
        //        break;
        //    case "Puzzle_Cajas":
        //        if (TextosLibro.Length > 5)
        //            TextosLibro[5].SetActive(true);
        //        break;
        //    case "Puzzle_Llaves":
        //        if (TextosLibro.Length > 6)
        //            TextosLibro[6].SetActive(true);
        //        break;
        //    case "Puzzle_Puertas":
        //        if (TextosLibro.Length > 7)
        //            TextosLibro[7].SetActive(true);
        //        break;
        //    case "Puzzle_Laberinto":
        //        if (TextosLibro.Length > 8)
        //            TextosLibro[8].SetActive(true);
        //        break;

        //        // Puedes seguir agregando más casos:
        //        // case "Puzzle_Rocas": pagPuzzles[2].SetActive(true); break;
        //}

        // Mostrar icono brillante en pantalla
        if (iconoDescubrimiento != null)
            StartCoroutine(MostrarIconoTemporal());
    }
    public void ActualizarDescubiertos(string id) 
    {
        for (int i = 0; i < textosLibro.Length; i++)
        {
            if (textosLibro[i] == id)
            {
                TextosLibro[i].SetActive(true);
            }
        }
        //switch (id)
        //{
        //    case "Trampa_Oso":
        //        // Hacemos visible el texto o imagen de la trampa de oso
        //        // Supongamos que la página está en pagTrampas[0]
        //        if (pagTrampas.Length > 0)
        //            TextosLibro[0].SetActive(true);
        //        break;

        //    case "Trampa_Jaula":
        //        if (pagTrampas.Length > 1)
        //            TextosLibro[1].SetActive(true);
        //        break;

        //    case "Puzzle_Escombros":
        //        if (pagTrampas.Length > 2)
        //            TextosLibro[2].SetActive(true);
        //        break;

        //        // Puedes seguir agregando más casos:
        //        // case "Puzzle_Rocas": pagPuzzles[2].SetActive(true); break;
        //}

    }
    private IEnumerator MostrarIconoTemporal()
    {
        iconoDescubrimiento.SetActive(true);
        yield return new WaitForSeconds(7f); // 3 segundos visible
        iconoDescubrimiento.SetActive(false);
    }
    public void EntrarPantallaCinematica() 
    {
        PantallaCinematica[0].SetActive(!PantallaCinematica[0].activeSelf);
        PantallaCinematica[1].SetActive(!PantallaCinematica[1].activeSelf);
        PantallaPuzzles[0].SetActive(false);
        PantallaPuzzles[1].SetActive(false);
        PantallaTrampas[0].SetActive(false);
        PantallaTrampas[1].SetActive(false);
        PantallaObjetos[0].SetActive(false);
        PantallaObjetos[1].SetActive(false);
        botones[0].SetActive(false);
        botones[1].SetActive(true);
        botones[2].SetActive(true);
        botones[3].SetActive(true);
    }
    public void EntrarPantallaPuzzles()
    {
        PantallaPuzzles[0].SetActive(!PantallaPuzzles[0].activeSelf);
        PantallaPuzzles[1].SetActive(!PantallaPuzzles[1].activeSelf);
        PantallaTrampas[0].SetActive(false);
        PantallaTrampas[1].SetActive(false);
        PantallaObjetos[0].SetActive(false);
        PantallaObjetos[1].SetActive(false);
        PantallaCinematica[0].SetActive(false);
        PantallaCinematica[1].SetActive(false);
        botones[0].SetActive(true);
        botones[1].SetActive(false);
        botones[2].SetActive(true);
        botones[3].SetActive(true);
    }
    public void EntrarPantallaTrampas()
    {
        PantallaTrampas[0].SetActive(!PantallaTrampas[0].activeSelf);
        PantallaTrampas[1].SetActive(!PantallaTrampas[1].activeSelf);
        PantallaObjetos[0].SetActive(false);
        PantallaObjetos[1].SetActive(false);
        PantallaCinematica[0].SetActive(false);
        PantallaCinematica[1].SetActive(false);
        PantallaPuzzles[0].SetActive(false);
        PantallaPuzzles[1].SetActive(false);
        botones[0].SetActive(true);
        botones[1].SetActive(true);
        botones[2].SetActive(false);
        botones[3].SetActive(true);
    }
    public void EntrarPantallaObjetos()
    {
        PantallaObjetos[0].SetActive(!PantallaObjetos[0].activeSelf);
        PantallaObjetos[1].SetActive(!PantallaObjetos[1].activeSelf);
        PantallaPuzzles[0].SetActive(false);
        PantallaPuzzles[1].SetActive(false);
        PantallaTrampas[0].SetActive(false);
        PantallaTrampas[1].SetActive(false);
        PantallaCinematica[0].SetActive(false);
        PantallaCinematica[1].SetActive(false);
        botones[0].SetActive(true);
        botones[1].SetActive(true);
        botones[2].SetActive(true);
        botones[3].SetActive(false);
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
                pagCine = Limite(pagCine, pagCinematica.Length);
                pagCinematica[pagCine].SetActive(true);
                pagCinematica[pagCine + 1].SetActive(true);
            }
            else if (PantallaPuzzles[0].activeSelf)
            {
                pagPuzzles[pagPuzle].SetActive(false);
                pagPuzzles[pagPuzle + 1].SetActive(false);
                pagPuzle -= 2;
                pagPuzle = Limite(pagPuzle, pagPuzzles.Length);
                pagPuzzles[pagPuzle].SetActive(true);
                pagPuzzles[pagPuzle + 1].SetActive(true);
            }
            else if (PantallaTrampas[0].activeSelf)
            {
                pagTrampas[pagTramp].SetActive(false);
                pagTrampas[pagTramp + 1].SetActive(false);
                pagTramp -= 2;
                pagTramp = Limite(pagTramp, pagTrampas.Length);
                pagTrampas[pagTramp].SetActive(true);
                pagTrampas[pagTramp + 1].SetActive(true);
            }
            else if (PantallaObjetos[0].activeSelf)
            {
                pagObjetos[pagObj].SetActive(false);
                pagObjetos[pagObj + 1].SetActive(false);
                pagObj -= 2;
                pagObj = Limite(pagObj, pagObjetos.Length);
                pagObjetos[pagObj].SetActive(true);
                pagObjetos[pagObj + 1].SetActive(true);
            }
        }
        else if(cambio == 1)
        {
            if (PantallaCinematica[0].activeSelf)
            {
                pagCinematica[pagCine].SetActive(false);
                pagCinematica[pagCine + 1].SetActive(false);
                pagCine += 2;
                pagCine = Limite(pagCine, pagCinematica.Length);
                pagCinematica[pagCine].SetActive(true);
                pagCinematica[pagCine + 1].SetActive(true);
            }
            else if (PantallaPuzzles[0].activeSelf)
            {
                pagPuzzles[pagPuzle].SetActive(false);
                pagPuzzles[pagPuzle + 1].SetActive(false);
                pagPuzle += 2;
                pagPuzle = Limite(pagPuzle, pagPuzzles.Length);
                pagPuzzles[pagPuzle].SetActive(true);
                pagPuzzles[pagPuzle + 1].SetActive(true);
            }
            else if (PantallaTrampas[0].activeSelf)
            {
                pagTrampas[pagTramp].SetActive(false);
                pagTrampas[pagTramp + 1].SetActive(false);
                pagTramp += 2;
                pagTramp = Limite(pagTramp, pagTrampas.Length);
                pagTrampas[pagTramp].SetActive(true);
                pagTrampas[pagTramp + 1].SetActive(true);
            }
            else if (PantallaObjetos[0].activeSelf) // 0, 1, 2, 3
            {
                pagObjetos[pagObj].SetActive(false);
                pagObjetos[pagObj + 1].SetActive(false);
                pagObj += 2;
                pagObj = Limite(pagObj, pagObjetos.Length);
                pagObjetos[pagObj].SetActive(true);
                pagObjetos[pagObj + 1].SetActive(true);
            }
        }

    }
    int Limite(int variable, int limite) 
    {
        variable = Mathf.Clamp(variable, 0, limite - 1);
        if (variable == limite - 1)
            return variable - 1;
        if (variable < 0) variable = 0;
        return variable;
    }
    private void Update()
    {
        
    }
}
