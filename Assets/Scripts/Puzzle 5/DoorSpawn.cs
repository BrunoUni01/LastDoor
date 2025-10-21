using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnDestino;
    [SerializeField] private bool siguienteHabitacion;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        collision.transform.position = spawnDestino.position; // aca hace el tp para el player
    }
}
