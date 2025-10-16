using UnityEngine;

public class Caida : MonoBehaviour
{
    private Rigidbody2D body;
    public Transform spawnDestino;
    private bool fall1;
    [SerializeField] private bool isTrapdoor;
    [SerializeField] private bool estante;
    [SerializeField] private bool fall2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fall1 = false;
        isTrapdoor = false;
        estante = false;
        fall2 = false;
    }

    private void Update()
    {
        if (fall1)
        {
            Invoke(nameof(Respawn),2f);
            fall1 = false;
        }
        if (estante)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTrapdoor = true;
            }
        }
        if (fall2 && isTrapdoor)
        {
            Invoke(nameof(Respawn), 2f);
            fall2 = false;
        }
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tabla"))
        {
            fall1 = true;
        }

        if (collision.CompareTag("Estante"))
        {
            estante = true;
        }
        if (collision.CompareTag("Tabla2"))
        {
            fall2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tabla"))
        {
            fall1 = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Estante"))
        {
            estante = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Estante"))
        {
            estante = false;
        }
    }

    private void Respawn()
    {
        transform.position = spawnDestino.position;
    }
}
