using UnityEngine;

public class TrampaJaula : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private bool inPlayer;
    [SerializeField] private bool finTrampa;
    [SerializeField] private bool condicion;
    [SerializeField] private bool inTrap;
    [SerializeField] private int contador;
    [SerializeField] private LayerMask capaTrampaStuck;
    private KeyCode[] teclasValidas;
    private int random;
    private int canPress;
    private void Awake()
    {
        teclasValidas = new KeyCode[]{ KeyCode.G, KeyCode.H, KeyCode.Y, KeyCode.T, KeyCode.U, KeyCode.J, KeyCode.Space };
    }
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        finTrampa = false;
        condicion = false;
        random = Random.Range(0, teclasValidas.Length);
        canPress = Random.Range(10, 21);
    }
    void ValidacionPlayer()
    {
        if (finTrampa)
        {
            inPlayer = false;
            return;
        }
        if (player.RayoSuelo(capaTrampaStuck) && inTrap)
        {
            EventManager.ReportDiscovery("Trampa_Jaula");
            inPlayer = true;
        }
        else
        {
            inPlayer = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        inTrap = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        inTrap = false;
    }
    // Update is called once per frame
    void Update()
    {
        ValidacionPlayer();
        if (inPlayer) 
        {
            TrampaStuckManager.instancia.ActivarTrampaPorCondicion(player, () => condicion);

            if (Input.GetKeyDown(teclasValidas[random]))
            {
                contador++;
            }
            if (contador >= canPress) 
            {
                condicion = true;
            }
            if (condicion) 
            {
                finTrampa = true;
            }
        }
        
    }
}
