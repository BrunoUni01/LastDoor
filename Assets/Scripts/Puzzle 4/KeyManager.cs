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
        n = Random.Range(8, 13); // asigno cantidad
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
        for (int i = puntosSpawn.Count - 1; i > 0; i--) // Se mezclan los códigos
        {
            var j = Random.Range(0, i + 1);
            var temp = puntosSpawn[i];
            puntosSpawn[i] = puntosSpawn[j];
            puntosSpawn[j] = temp;
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

        for (int i = llaves.Count - 1; i > 0; i--) // llaves
        {
            var j = Random.Range(0, i + 1);
            var temp = llaves[i];
            llaves[i] = llaves[j];
            llaves[j] = temp;
        }

        for (int i = llaves.Count - 1; i > 0; i--) // puntos de spawn
        {
            var j = Random.Range(0, i + 1);
            var temp = llaves[i].GetComponent<Key>().spawn;
            llaves[i].GetComponent<Key>().spawn = llaves[j].GetComponent<Key>().spawn;
            llaves[j].GetComponent<Key>().spawn = temp;
        }
        int LF = Random.Range(2, 5);
        int LR = llaves.Count - LF; // 8 - 2 = 6 
        List<GameObject> llavesReales = new List<GameObject>();
        for (int i = 0; i < LR; i++) // se asignan los códigos a las llaves
        {
            llaves[i].GetComponent<Key>().codigo = codigos[i];
            llavesReales.Add(llaves[i]);
        }
        for (int i = LR; i < LR + LF; i++) 
        {
            llaves[i].GetComponent<Key>().codigo = -1;
        }
        AsignarCodigos(llavesReales);


    }
    void AsignarCodigos(List<GameObject> RealKeys)
    {
        candados.AsignarCodigos(RealKeys);
    }
}

