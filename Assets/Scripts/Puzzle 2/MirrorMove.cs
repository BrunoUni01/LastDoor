using UnityEngine;

public class MirrorMove : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float velocidad;
    public bool clear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clear = false;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 movimiento = new Vector2(-x, -y);
        body.linearVelocity = movimiento.normalized * velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pink"))
        {
            clear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pink"))
        {
            clear = false;
        }
    }
}