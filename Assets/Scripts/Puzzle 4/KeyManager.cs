using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class KeyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] List<Transform> puntosSpawn; // 10 puntos de spawn
    [SerializeField] List<GameObject> llaves; // 6 - 8 llaves // 1 - 3 
    [SerializeField] Candados candados;
    [SerializeField] int[] codigos;
    [SerializeField] private int n;
    [SerializeField] GameObject llave;



    private void Awake()
    {
        int n = Random.Range(6, 9); // asigno cantidad
        codigos = new int[n]; // inicializa la variable
        for (int i = 0; i < codigos.Length; i++) //inicializan los códigos
            codigos[i] = i;
        for (int i = codigos.Length - 1; i > 0; i--) // Se mezclan los códigos
        {
            var j = Random.Range(0, i + 1);
            var temp = codigos[i];
            codigos[i] = codigos[j];
            codigos[j] = temp;
        }
        llaves = new List<GameObject>();//
        CrearLlaves(n);
    }
    void CrearLlaves(int n)
    {
        for (int i = n - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1);
            var temp = puntosSpawn[i];
            puntosSpawn[i] = puntosSpawn[j];
            puntosSpawn[j] = temp;
            llaves.Add(Instantiate(llave, puntosSpawn[i].position,Quaternion.identity));
        }
    }
    void Start()
    {


        //for (int i = n - 1; i > 0; i--) //barajea los indices de forma random
        //{
        //    int j = Random.Range(0, i + 1);
        //    int temp = indices[i];
        //    indices[i] = indices[j];
        //    indices[j] = temp;
        //}

        for (int i = n - 1; i > 0; i--) // llaves
        {
            var j = Random.Range(0, i + 1);
            var temp = llaves[i];
            llaves[i] = llaves[j];
            llaves[j] = temp;
        }

        for (int i = n - 1; i > 0; i--) // puntos de spawn
        {
            var j = Random.Range(0, i + 1);
            var temp = llaves[i].GetComponent<Key>().spawn;
            llaves[i].GetComponent<Key>().spawn = llaves[j].GetComponent<Key>().spawn;
            llaves[j].GetComponent<Key>().spawn = temp;
        }
        for (int i = 0; i < llaves.Count; i++) // se asignan los códigos a las llaves
        {
            llaves[i].GetComponent<Key>().codigo = codigos[i];
        }
        AsignarCodigos();
        //Respawn();






    }
    void Respawn()
    {
        foreach (var item in llaves) //spawnea las llaves en sus respectivas posiciones
        {
            item.GetComponent<Key>().Respawn();
        }
    }
    void AsignarCodigos()
    {
        candados.AsignarCodigos(llaves);
    }
}

//public int[] CodigosIguales() 
//{
//    return codigos;
//}

//private void VerificarOrden() 
//{
//    for (int i = 0; i < llaves.Count; i++)
//    {
//        if (llaves[i].activado && (llaves[i].codigo == candados.CodigosRecibidos()[i])) 
//        {
//            candados.CodigosActivados[i] = true;
//        }
//    }
//}
//private void VerificarOrden()
//{
//    for (int i = 0; i < PalancaList.Count - 1; i++) // verificar todos los indices
//    {
//        if (i != 0) // no tomar en cuenta el primero
//        {
//            int j = i + 1;
//            if (PalancaList[indices[i]].Activado == false && PalancaList[indices[j]].Activado == true) //verifica si ha accionado la palanca en el orden correcto
//            {
//                ResetPalancas(); //reset si no se hizo en el orden correcto
//            }

//        }
//    }
//}