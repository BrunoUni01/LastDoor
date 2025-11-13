using System.Collections.Generic;
using UnityEngine;

public class DiscoveryManager : MonoBehaviour
{
    private List<string> discoveredList = new List<string>();
    [SerializeField] LibroManager libroManager;

    void Awake()
    {
        // Registrar este manager en el EventManager
        EventManager.discoveryManager = this;
        //ResetProgress();
        LoadProgress();
    }

    public void OnDiscovery(string id)
    {
        // Este método lo llama el EventManager
        if (!discoveredList.Contains(id))
        {
            discoveredList.Add(id);
            Debug.Log("Nuevo descubrimiento: " + id);
            SaveProgress();
            if (libroManager != null) 
            {
                libroManager.DesbloquearEntrada(id);
            }
        }
    }

    private void SaveProgress()
    {
        string data = string.Join(",", discoveredList);
        PlayerPrefs.SetString("DiscoveredList", data);
        PlayerPrefs.Save();
    }

    private void LoadProgress()
    {
        string data = PlayerPrefs.GetString("DiscoveredList", "");
        if (!string.IsNullOrEmpty(data))
        {
            discoveredList = new List<string>(data.Split(','));
        }

        if (libroManager != null)
        {
            foreach (string id in discoveredList)
            {
                print(id);
                libroManager.ActualizarDescubiertos(id);
            }
        }
    }

    public bool IsDiscovered(string id)
    {
        return discoveredList.Contains(id);
    }

    public void ResetProgress()
    {
        discoveredList.Clear();
        PlayerPrefs.DeleteKey("DiscoveredList");
        PlayerPrefs.Save();
    }
}
