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
        print("aaaaa");
        if (!collision.CompareTag("CajaPuzTres")) { return; }
        var caja = collision.gameObject.GetComponent<Box_Number>().numero;
        print("que esta pasando");
        validacion = placa.Validacion(caja);
        if (validacion)
        {
            //collision.gameObject.GetComponent<PushableObject>().Validador(transform);
            atraer = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("dddddd");
        if (!collision.CompareTag("CajaPuzTres")) { return; }
        if (validacion)
        {
            print("que esta");
            //collision.gameObject.GetComponent<PushableObject>().target = null;
            validacion = false;
            atraer = true;
        }
    }
}
