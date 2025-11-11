using UnityEngine;

public class OpenEscombrosScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Puerta puerta;
    [SerializeField] Transform PuzTuCamara;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool inPlayer;
    [SerializeField] Transform spawnHabitacion;
    [SerializeField] private Escombros puzzleTutorial;
  
    private void Start()
    {
        puerta = GetComponent<Puerta>();
        puerta.locked = true;
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        puzzleTutorial = FindAnyObjectByType<Escombros>();
        if (puerta != null) puerta.locked = true;
    }
    void Update()
    {
        if (inPlayer && Input.GetKeyDown(KeyCode.E))
        {
            print("si entroooo");
            EnterPuzzle();
            EventManager.ReportDiscovery("Puzzle_Escombros");
        }
        else if (puzzleTutorial.FinEscombros())
        {
            ExitPuzzle();
            puerta?.Unlock();
            Destroy(this);
        }
    }
    void EnterPuzzle() 
    {
        Camera.main.transform.position = PuzTuCamara.position - new Vector3(0, 0, 10);
        playerMovement.gameObject.SetActive(false);
    }
    void ExitPuzzle() 
    {
        Camera.main.transform.position = spawnHabitacion.position - new Vector3(0, 0, 10);
        playerMovement.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            inPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inPlayer = false;
        }
    }
}
