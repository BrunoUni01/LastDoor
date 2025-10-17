using UnityEngine;

public class PullBox : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool dragging, moveBox;
    private Transform player;
    public float followSpeed = 0.5f;
    private PlayerMovement jugador;
    public float maxDistance = 1.2f;

    private void Awake()
    {
        moveBox = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        jugador = FindFirstObjectByType<PlayerMovement>();
        followSpeed = 0.5f;

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        dragging = true;
    //        player = collision.transform;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = collision.transform;
        dragging = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || transform.parent) return;
        player = null;
        dragging = false;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        dragging = false;
    //        player = null;
    //    }
    //}
    private void FixedUpdate()
    {
        Interact();
    }
    void Interact() 
    {
        if (/*!dragging || */!player) return;
        if (Input.GetKey(KeyCode.R))
        {
            //transform.SetParent(player);
            rb.bodyType = RigidbodyType2D.Dynamic;
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.position = player.position + Vector3.left * 1.1f;
        }
        else
        {
            //print("a");
            //transform.SetParent(null);
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    //private void FixedUpdate()
    //{
    //    Pull();
    //    if (!moveBox|| player == null) return;

    //    Vector2 direction = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    //    direction.Normalize();
    //    Vector2 targetPos = rb.position + direction * followSpeed * Time.fixedDeltaTime;
    //    rb.linearVelocity = direction;

    //    Solo moverse si el jugador se aleja más de la distancia límite
    //}
}
