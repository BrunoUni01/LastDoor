using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    [SerializeField] public Transform spawnDestino;
    [SerializeField] public bool siguienteHabitacion;

    [SerializeField] private GameObject[] puertas;

    private void Awake()
    {
        AsignarPosicionesyBools();
    }
    void AsignarPosicionesyBools()
    {

        for (int i = puertas.Length - 1; i > 0; i--) //[2].posición <-> [5].posición---> [2].bools <-> [5].bools
    {
            var j = Random.Range(0, i + 1);
            var temp = puertas[i].GetComponent<DoorSpawn>().spawnDestino;
            puertas[i].GetComponent<DoorSpawn>().spawnDestino = puertas[j].GetComponent<DoorSpawn>().spawnDestino;
            puertas[j].GetComponent<DoorSpawn>().spawnDestino = temp;

            var temp2 = puertas[i].GetComponent<DoorSpawn>().siguienteHabitacion;
            puertas[i].GetComponent<DoorSpawn>().siguienteHabitacion = puertas[j].GetComponent<DoorSpawn>().siguienteHabitacion;
            puertas[j].GetComponent<DoorSpawn>().siguienteHabitacion = temp2;
            Verificacion(j);
        }

    }
    void Verificacion(int i) 
    {
        Transform puerta = puertas[i].GetComponent<DoorSpawn>().spawnDestino;
        Transform hijo = puertas[i].GetComponent<DoorSpawn>().GetComponentInChildren<Transform>();
        if (puerta == hijo) 
        {
            Shuffle(i);
        }
        return;
    }
    void Shuffle(int pos) 
    {
        var j = Random.Range(0, pos + 1);
        var temp = puertas[pos - 1].GetComponent<DoorSpawn>().spawnDestino;
        puertas[pos - 1].GetComponent<DoorSpawn>().spawnDestino = puertas[j].GetComponent<DoorSpawn>().spawnDestino;
        puertas[j].GetComponent<DoorSpawn>().spawnDestino = temp;

        var temp2 = puertas[pos - 1].GetComponent<DoorSpawn>().siguienteHabitacion;
        puertas[pos - 1].GetComponent<DoorSpawn>().siguienteHabitacion = puertas[j].GetComponent<DoorSpawn>().siguienteHabitacion;
        puertas[j].GetComponent<DoorSpawn>().siguienteHabitacion = temp2;
        Verificacion(j);
    }
}
