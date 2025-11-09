using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance { get; private set; }

    //ref
    public CamaraController cameraController;
    private RoomFade fade;
    private Cuarto cuartoActual;
    private Score jugador;
    private HUD_barra hud_Barra;
    //private Scroll current;
    public bool isTransitioning { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        jugador = FindFirstObjectByType<Score>();
        hud_Barra = FindFirstObjectByType<HUD_barra>();
        fade = FindAnyObjectByType<RoomFade>();
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
        //fade.IniciaFadeOut();
        fade.FadeOut();
        hud_Barra.getScroll().SetEjecucion(false); // cancela la ejecucion del scroll actual para evitar que el player se muera
        yield return new WaitUntil(fade.getFadeout()); // espera a que el fade termine de realizarse ( false -> true)

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
        if(hud_Barra != null)
        hud_Barra.ChangeScroll(actual);
        hud_Barra.getScroll().SetEjecucion(false);


        player.transform.position = spawnJugador;


        if (cameraController != null)
            cameraController.MoverACuarto(nuevoCuarto.Focus.position, true);
        yield return null;

        Puerta[] puertas = cuartoActual.GetComponentsInChildren<Puerta>(true);
        foreach (var p in puertas) p.Unlock();
        fade.Fadein();// como ya paso de habitación empieza a aclararse
        yield return new WaitUntil(fade.getFadein());// espera a que fadeIn termine de hacer su ejecución
        hud_Barra.getScroll().SetEjecucion(true); // lo activa nuevamente por si acaso
        isTransitioning = false;
    }
}
