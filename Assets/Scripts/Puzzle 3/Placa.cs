using System.Collections;
using TMPro;
using UnityEngine;

public class Placa : MonoBehaviour
{
    CustomYieldInstruction _condicional;
    [SerializeField] public Box_Number _numberBox;
    [SerializeField] private int number;
    [SerializeField] TextMeshPro _textMeshPro;
    private int randomCon;
    void Start()
    {
        _textMeshPro =GetComponentInChildren<TextMeshPro>();
        randomCon = Random.Range(1, 4);
        //int randomRan = Random.Range(1, 11);
        //switch (randomCon) // los rangos serán de 0 - 100
        //{
        //    case 1: _condicional = new WaitUntil(() => Caso1()); print("Caja Mayor!"); break;
        //    case 2: _condicional = new WaitUntil(() => Caso2()); print("Caja Menor!"); break;
        //    case 3: _condicional = new WaitUntil(() => Caso3()); print("Caja Igual!"); break;
        //}
        //AsignarNumber(randomCon);
        AsignarNumeros(randomCon, AsignarNumber(randomCon));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Validacion(int num) 
    {
        if (randomCon == 1)
        {
            return Caso1(num);
        }
        else if (randomCon == 2) 
        {
            return Caso2(num);
        }
        else
        {
            return Caso3(num);
        }
    }
    bool Caso1(int caja) // mayor: La caja debe ser mayor que la placa
    {
        return caja > number;
    }
    bool Caso2(int caja) // menor: La caja debe ser menor que la placa
    {
        return caja < number;
    }
    bool Caso3(int caja) // igual: La caja debe ser igual que la placa
    {
        return caja == number;
    }

    int AsignarNumber(int condicional) // la placa
    {
        int ind = -1;
        int[] ranAleatorios = {(int)Random.Range(1,11),
                            (int)Random.Range(10, 21),
                            (int)Random.Range(20, 31),
                            (int)Random.Range(30, 41),
                            (int)Random.Range(40,51),
                            (int)Random.Range(50, 61),
                            (int)Random.Range(60, 71),
                            (int)Random.Range(70, 81),
                            (int)Random.Range(80,91),
                            (int)Random.Range(90, 101)};
        if (condicional == 1) // mayor: La caja debe ser mayor que la placa
        {
            
            ind = Random.Range(0,9);
            number = ranAleatorios[ind];
            _textMeshPro.text = $"Caja > {number}";
        }
        if (condicional == 2) // menor: La caja debe ser menor que la placa
        {
            ind = Random.Range(1, 10);
            number = ranAleatorios[ind];
            _textMeshPro.text = $"Caja < {number}";
        }
        if (condicional == 3) // igual: La caja debe ser igual que la placa
        {
            ind = Random.Range(0, 10);
            number = ranAleatorios[ind];
            _textMeshPro.text = $"Caja == {number}";
        }
        
        return ind;
    }
    void AsignarNumeros(int condicional, int rango) // la caja
    {
        int[] numAleatorios = {(int)Random.Range(1,11),
                            (int)Random.Range(10, 21),
                            (int)Random.Range(20, 31),
                            (int)Random.Range(30, 41),
                            (int)Random.Range(40,51),
                            (int)Random.Range(50, 61),
                            (int)Random.Range(60, 71),
                            (int)Random.Range(70, 81),
                            (int)Random.Range(80,91),
                            (int)Random.Range(90, 101)};

        if (condicional == 1) // mayor: La caja debe ser mayor que la placa
        {
            _numberBox.numero = numAleatorios[Random.Range(rango + 1, 10)];
            
        }
        if (condicional == 2) // menor: La caja debe ser menor que la placa
        {
            _numberBox.numero = numAleatorios[Random.Range(0, rango - 1)];
        }
        if (condicional == 3) // igual: La caja debe ser igual que la placa
        {
            _numberBox.numero = number;
        }
        _numberBox.AsignarTexto();
    }
}
