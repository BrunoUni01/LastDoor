using UnityEngine;
using System.Collections;

public class TrampaStuckManager : MonoBehaviour
{
    public static TrampaStuckManager instancia;
    private bool activadoDuracion;
    private bool activadoCondicion;
    private void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);
        activadoDuracion = false;
        activadoCondicion = false;
    }

    public void ActivarTrampaPorDuracion(PlayerMovement player, float duracion)
    {
        if (activadoDuracion) return;
        activadoDuracion = true;
        StartCoroutine(EjecucionTrampaDuracion(player, duracion));
    }
    private IEnumerator EjecucionTrampaDuracion(PlayerMovement player, float duracion)
    {
        player.ActivarStuck();  // Bloquea movimiento
        yield return new WaitForSeconds(duracion);
        player.DesactivarStuck();
        activadoDuracion = false;
    }
    public void ActivarTrampaPorCondicion(PlayerMovement player, System.Func<bool> condicion) // System.Func<bool> garantiza de que la variable se verifica constantemente a tiempo real
    {
        if (activadoDuracion) return;
        activadoDuracion = true;
        StartCoroutine(EjecucionTrampaCondicion(player, condicion));
    }

    

    private IEnumerator EjecucionTrampaCondicion(PlayerMovement player, System.Func<bool> condicion)
    {
        player.ActivarStuck();  // Bloquea movimiento
        yield return new WaitUntil(() => condicion());
        player.DesactivarStuck();
        activadoDuracion = false;
    }
}