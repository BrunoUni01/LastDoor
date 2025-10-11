using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    
    [SerializeField] private Puerta door;
    [SerializeField] List<Placa> placaList;
    [SerializeField] List<Box_Number> cajas;
    [SerializeField] List<Validador> Validadores;
    void Awake()
    {
        Validadores = new List<Validador>();


        foreach (var placa in placaList) 
        Validadores.Add(placa.gameObject.GetComponent<Validador>());


        for (int i = placaList.Count - 1; i > 0; i--) 
        {
            int j = Random.Range(0, i + 1);
            var temp = placaList[i]._numberBox;
            placaList[i]._numberBox = placaList[j]._numberBox;
            placaList[j]._numberBox = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarTodo();
    }
    void ComprobarTodo() 
    {
        if (Validadores.Exists(x=> x.validacion == false))
        {
            door.locked = true;
            return;
        }
        door.locked = false;

    }
}
