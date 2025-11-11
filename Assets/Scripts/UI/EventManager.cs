using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static DiscoveryManager discoveryManager;

    // Llamado por otros scripts cuando se descubre algo
    public static void ReportDiscovery(string id)
    {
        if (discoveryManager != null)
        {
            discoveryManager.OnDiscovery(id);
        }
        else
        {
            Debug.LogWarning("No hay DiscoveryManager registrado para recibir eventos.");
        }
    }
}
