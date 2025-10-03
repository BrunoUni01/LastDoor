using UnityEditor.EditorTools;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Cuarto cuartoDestino;
    public Transform spawnDestino;
    [SerializeField] Scroll scrollActual;
    [SerializeField] Scroll siguienteScroll;
    [HideInInspector] public bool locked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (locked) return;
        if (!other.CompareTag("Player")) return;

        locked = true;
        scrollActual.SetEjecucion(false);
        RoomManager.Instance.EntrarCuarto(cuartoDestino, spawnDestino.position, siguienteScroll);
    }
    public void Unlock() => locked = false; 
}
