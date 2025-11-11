using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class TrampaDeOso : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerMovement player;
    [SerializeField] private bool inPlayer;
    [SerializeField] private bool finTrampa;
    [SerializeField] private float cooldown;
    [SerializeField] private LayerMask capaTrampaStuck;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        finTrampa = false;
        cooldown = 0.10f;
    }

    //IEnumerator ejecucion()
    //{
    //    InicioTrampa();
    //    yield return new WaitForSeconds(3f);
    //    FinTrampa();
    //}
    //void InicioTrampa() 
    //{
    //    player.ActivarStuck();
    //}
    //void FinTrampa() 
    //{
    //    player.DesactivarStuck();
    //    finTrampa = true;

    //}
    void ValidacionPlayer() 
    {
        if (finTrampa)
        {
            inPlayer = false;
            return;
        }
        if (player.RayoSuelo(capaTrampaStuck))
        {
            inPlayer = true;
            EventManager.ReportDiscovery("TrampaDeOso");
        }
        else 
        {
            inPlayer= false;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Player")) return;
    //    inPlayer = true;
    //}
    private void Update()
    {
        ValidacionPlayer();
        if (inPlayer)
        {
            cooldown -= Time.deltaTime;
            cooldown = Mathf.Clamp(cooldown, 0f, 1f);
            if (cooldown <= 0) 
            {
                TrampaStuckManager.instancia.ActivarTrampaPorDuracion(player, 2f);
                finTrampa=true;
            }
        }
        else 
        {
            cooldown = 0.10f;
        }
    }
}
