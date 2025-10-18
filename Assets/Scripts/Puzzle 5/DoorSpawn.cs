using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnDestino;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = spawnDestino.position;
    }
}
