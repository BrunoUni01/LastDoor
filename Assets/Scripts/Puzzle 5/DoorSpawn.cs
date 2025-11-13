using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    [SerializeField] public Transform spawnDestino;
    [SerializeField] public bool siguienteHabitacion;
    [SerializeField] private Scroll scrollActual;
    [SerializeField] private Cuarto cuartoDestino;
    [SerializeField] private Scroll siguienteScroll;

    void TPsiguienteHabitacion()
    {
        scrollActual.SetEjecucion(false);
        RoomManager.Instance.EntrarCuarto(cuartoDestino, spawnDestino.position, siguienteScroll);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            EventManager.ReportDiscovery("Puzzle_Puertas");
            if (!siguienteHabitacion)
            {
                collision.transform.position = spawnDestino.position; // aca hace el tp para el player
            }
            else
            {
                TPsiguienteHabitacion();
            }
        }
    }
}
