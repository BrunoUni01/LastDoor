using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    [SerializeField] public Transform spawnDestino;
    [SerializeField] public bool siguienteHabitacion;

    [SerializeField] private GameObject[] puertas;

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
        }

    }
}
