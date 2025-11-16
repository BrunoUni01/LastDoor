using UnityEngine;


public class Puerta : MonoBehaviour
{
    public Cuarto cuartoDestino;
    public Transform spawnDestino;
    [SerializeField] Candados candado;
    [SerializeField] Scroll scrollActual;
    [SerializeField] Scroll siguienteScroll;
    [SerializeField] private OpenEscombrosScreen tempo;
    public bool locked;
    [SerializeField] SpriteRenderer activado;

    [Header("Puzzles")]
    [SerializeField] PuzzleClearEspejo puzzleEspejo;

    private void Awake()
    {
        //candado = null;
    }
    void LlaveCorrecta() 
    {
        activado.color = Color.green;
        Invoke(nameof(LlaveIncorrecta), 1);
    }
    void LlaveIncorrecta() 
    {
        activado.color= Color.red;
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
            if (candado != null)
            {  // si no tiene candado que no ejecute su código
                ThereCandado(other);
            }
            TherePuzzleTutorial();
            TherePuzzleEspejo();

        }

        if (locked) return;
        if (!other.CompareTag("Player")) return;

        //locked = true;
        scrollActual.SetEjecucion(false);
        RoomManager.Instance.EntrarCuarto(cuartoDestino, spawnDestino.position, siguienteScroll);
    }
    private void ThereCandado(Collider2D other) 
    {
        if (!candado.CandadosSacados()) //verifica si todos los candados han sido abiertos
        {
            locked = true; // coloca el seguro a la puerta
            PlayerInteraction jugador = other.GetComponent<PlayerInteraction>(); // consigue el interactor del player
            if (jugador == null) return; // seguridad
            if (jugador.objetoPermanente == null) return; // seguridad
            if (!jugador.objetoPermanente.TryGetComponent<Key>(out Key llave)) return; // verifica si el objeto permanente del player es una llave o no
                                                                                       //Key llave = jugador.objetoPermanente.GetComponent<Key>();
                                                                                       //if (llave == null) return;
            print("si tiene llave");
            if (candado.VerificarLlave(llave)) // verificación de la llave
            {
                LlaveCorrecta();
                Destroy(jugador.objetoPermanente);
            }
            else
            {
                LlaveIncorrecta(); // para la animación
            }
        }
        else
        {
            locked = false;
        }
    }
    private void TherePuzzleTutorial() 
    {
        tempo = GetComponent<OpenEscombrosScreen>();
        if (!tempo) return;
        if (!tempo.getEscombros()) return;
            if (tempo.getEscombros().activo) 
            {
                locked = true;

            }
            else
            {
                tempo.getEscombros().DisableGameobject();
                //locked = false;
            }
        
    }
    private void TherePuzzleEspejo() 
    {
        if (!puzzleEspejo) return;
        if (puzzleEspejo.puzzleclear)
            locked = false;
        else
            locked = true;
    }
    public void Unlock() => locked = false;


}