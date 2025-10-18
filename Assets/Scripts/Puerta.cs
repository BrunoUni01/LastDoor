using UnityEditor.EditorTools;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Cuarto cuartoDestino;
    public Transform spawnDestino;
    [SerializeField] Candados candado;
    [SerializeField] Scroll scrollActual;
    [SerializeField] Scroll siguienteScroll;
    [HideInInspector] public bool locked = false;

    private void Awake()
    {
        //candado = null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (collision.CompareTag("Puerta"))
        //{

        //    if (collision.gameObject.TryGetComponent(out Candados candado))
        //    {

        //    }
        //}
        if (other.CompareTag("Player"))
        {
            if (candado == null) return;
            if (!candado.CandadosSacados())
            {
                locked = true;
                PlayerInteraction jugador = other.GetComponent<PlayerInteraction>();
                if (jugador == null) return;
                if (jugador.objetoPermanente == null) return;
                if (!jugador.objetoPermanente.TryGetComponent<Key>(out Key llave)) return;
                //Key llave = jugador.objetoPermanente.GetComponent<Key>();
                //if (llave == null) return;
                print("si tiene llave");
                if (candado.VerificarLlave(llave)) Destroy(jugador.objetoPermanente);
            }
            else 
            {
                locked = false;
            }

        }

        if (locked) return;
        if (!other.CompareTag("Player")) return;

        locked = true;
        scrollActual.SetEjecucion(false);
        RoomManager.Instance.EntrarCuarto(cuartoDestino, spawnDestino.position, siguienteScroll);
    }
    public void Unlock() => locked = false;


}