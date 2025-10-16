using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Candados : MonoBehaviour
{
    int[] codigo;
    bool[] activados;
    public bool[] CodigosActivados { get => activados; set => activados = value; }
    void Start()
    {

    }
    public void AsignarCodigos(List<Key> a)
    {
        codigo = new int[a.Count];

        for (int i = 0; i < a.Count; i++)
        {
            codigo[i] = a[i].codigo;
        }
    }
    //public bool[] CodigosActivados() 
    //{
    //    return activados;
    //}
    public int[] CodigosRecibidos()
    {
        return codigo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
