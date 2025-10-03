using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PuzzlePalancas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<Palanca> PalancaList;
    [SerializeField] int[] indices;
    [SerializeField] private Puerta puertaActual;

    
    void Start() // Se hace uso del algoritmo de Fisher–Yates shuffle
    {
        puertaActual = GetComponent<Puerta>();
        int n = 5; 
        indices = new int[n];

        for (int i = 0; i < n; i++)
            indices[i] = i;

        for (int i = n - 1; i > 0; i--) //barajea los indices de forma random
        {
            int j = Random.Range(0, i + 1);
            int temp = indices[i];
            indices[i] = indices[j];
            indices[j] = temp;
        }
    }
    private void ResetPalancas() 
    {
        for (int i = 0; i < PalancaList.Count; i++)  //resetear todas las palancas 
        {
            PalancaList[indices[i]].Activado = false;
           
        }
    }
    private void TodoActivado() 
    {
        if (PalancaList.Exists(x => x.Activado == false)) //si aún sigue habiendo una palanca sin activar, la puerta sigue locked
        {
            puertaActual.locked = true;
            return;
        }

        puertaActual.locked = false;
    }
    private void VerificarOrden() 
    {
        for (int i = 0; i < PalancaList.Count - 1; i++) // verificar todos los indices
        {
            if (i != 0) // no tomar en cuenta el primero
            {
                int j = i + 1;
                if (PalancaList[indices[i]].Activado == false && PalancaList[indices[j]].Activado == true) //verifica si ha accionado la palanca en el orden correcto
                {
                    ResetPalancas(); //reset si no se hizo en el orden correcto
                }
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        VerificarOrden();
        TodoActivado(); 
    }
}
