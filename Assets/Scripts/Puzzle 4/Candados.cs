using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Candados : MonoBehaviour
{
    [SerializeField] List<int> codigo;
    [SerializeField] bool[] activados;
    public bool[] CodigosActivados { get => activados; set => activados = value; }
    void Start()
    {
        codigo = new List<int>();
    }
    public void AsignarCodigos(List<GameObject> llaves)
    {

        foreach (var key in llaves)
        {
            codigo.Add(key.GetComponent<Key>().codigo);
        }
        activados = new bool[codigo.Count];
    }
    public bool VerificarLlave(Key llave)
    {
        if (codigo.Exists(x => x == llave.codigo))
        {
            activados[codigo.IndexOf(llave.codigo)] = true;
            return true;
        }
        return false;
    }
    public bool CandadosSacados() 
    {
        for (int i = 0; i < activados.Length; i++)
        {
            if (!activados[i]) return false;
        }
        return true;
    }

    public bool PuertaAbierta()
    {
        foreach (var item in activados)
        {
            if (!item) return false;
        }
        return true;
    }
    //public bool[] CodigosActivados() 
    //{
    //    return activados;
    //}
    public List<int> CodigosRecibidos()
    {
        return codigo;
    }

    // Update is called once per frame
    
}