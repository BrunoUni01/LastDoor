using UnityEngine;

public class Validador : MonoBehaviour
{
    [SerializeField] private Placa placa;
    public bool validacion;
    public bool atraer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        atraer = true;
        placa = GetComponent<Placa>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("CajaPuzTres") || !atraer) { return; }
        var caja = collision.gameObject.GetComponent<Box_Number>().numero;
        validacion = placa.Validacion(caja);
        if (validacion)
        {
            collision.gameObject.GetComponent<PushableObject>().Validador(transform);
            atraer = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("CajaPuzTres")) { return; }
        if (validacion)
        {
            collision.gameObject.GetComponent<PushableObject>().target = null;
            validacion = false;
            atraer = true;
        }
    }
}
