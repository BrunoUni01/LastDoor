using UnityEngine;

public class PullBox : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool dragging, moveBox;
    private Transform player;
    public float followSpeed = 0.5f;
    private PlayerMovement jugador;
    public float maxDistance = 1.2f;
    private float distance;
    private bool a = true;

    private void Awake()
    {
        moveBox = false;
        rb = GetComponentInParent<Rigidbody2D>();

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
        dragging = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
            player = null;
            dragging = false; 
            //dragging = false;
        
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
        if (player == null) 
        {
            rb.bodyType = RigidbodyType2D.Static;
            dragging = false;
            return;
        }
        if (Input.GetKey(KeyCode.R))
        {
            //transform.SetParent(player);
            dragging = true;
            Vector2 pos = Direccion();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0f;
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.position = (Vector2)player.position + pos * distance;
        }
        else
        {
            //print("a");
            //transform.SetParent(null);
            rb.bodyType = RigidbodyType2D.Static;
            dragging = false;
        }
    }

    Vector2 Direccion() 
    {
        BoxCollider2D playerCol = player.GetComponent<BoxCollider2D>();
        BoxCollider2D boxCol = GetComponentInParent<BoxCollider2D>();

        Vector2 playerSize = Vector2.Scale(playerCol.size, player.lossyScale);
        Vector2 boxSize = Vector2.Scale(boxCol.size, transform.lossyScale);

        Vector2 dir = (transform.position - player.position).normalized;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            distance = (playerSize.x + boxSize.x) / 2f - 0.20f;
            if (dir.x > 0)
            {
                //distance = 1.1f;
                return Vector2.right;
            }
            else
            {
                //distance = 1.1f;
                return Vector2.left;
            }
        }
        else 
        {
            distance = (playerSize.y + boxSize.y) / 2f - 0.20f;
            if (dir.y > 0)
            {
                //distance = 1.6f;
                return Vector2.up;
            }
            else 
            {
                //distance = 1.6f;
                return Vector2.down;
            }
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
