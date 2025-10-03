using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance { get; private set; }

    //ref
    public CamaraController cameraController;
    private Cuarto cuartoActual;
    private Score jugador;
    //private Scroll current;
    public bool isTransitioning { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        jugador = FindFirstObjectByType<Score>();
    }

    public void EntrarCuarto(Cuarto nuevoCuarto, Vector3 spawnJugador, Scroll a)
    {
        if (isTransitioning) return;
        StartCoroutine(CambiarCuarto(nuevoCuarto, spawnJugador, a));
    }
    
    
    private IEnumerator CambiarCuarto(Cuarto nuevoCuarto, Vector3 spawnJugador, Scroll actual)
    {
        isTransitioning = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        //if (cuartoActual != null) cuartoActual.gameObject.SetActive(false);

        nuevoCuarto.gameObject.SetActive(true);
        cuartoActual = nuevoCuarto;

        if (actual != null)
        {
            jugador.ActualizarScroll(actual);
            actual.gameObject.SetActive(true);
        }


        player.transform.position = spawnJugador;


        if (cameraController != null)
            cameraController.MoverACuarto(nuevoCuarto.Focus.position, true);
        yield return null;

        Puerta[] puertas = cuartoActual.GetComponentsInChildren<Puerta>(true);
        foreach (var p in puertas) p.Unlock();

        isTransitioning = false;
    }
}
