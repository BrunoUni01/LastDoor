using UnityEngine;

public class PullBox : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] BoxCollider2D box;
    [SerializeField] private bool dragging, inPlayer;
    private Transform player;
    public float followSpeed = 0.5f;
    private PlayerMovement jugador;
    public float maxDistance = 1.2f;
    private Vector2 distance;
    private bool a = true;

    private void Awake()
    {
        inPlayer = false;
        rb = GetComponentInParent<Rigidbody2D>();

    }
    private void Start()
    {
        jugador = FindFirstObjectByType<PlayerMovement>();
        followSpeed = 0.5f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = collision.transform;
        dragging = false;
        inPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (!dragging)
        {
            player = null;
            dragging = false;
            inPlayer = false;
        }
    }
    
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Player")) return;
    //    if (!dragging)
    //    {
    //        player = null;
    //        dragging = false;
    //    }
    //        //dragging = false;
        
    //}

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
        if (Input.GetKey(KeyCode.R) && inPlayer)
        {
            //transform.SetParent(player);
            dragging = true;
            Vector2 dir = Direccion();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0f;
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Vector2 targetPos = (Vector2)player.position + dir * distance;
            rb.MovePosition(targetPos);
        }
        else
        {
            //print("a");
            //transform.SetParent(null);
            rb.bodyType = RigidbodyType2D.Static;
            dragging = false;
            //inPlayer = false;
        }

    }

    Vector2 Direccion() 
    {
        BoxCollider2D playerCol = player.GetComponent<BoxCollider2D>();
        //BoxCollider2D boxCol = GetComponentInParent<BoxCollider2D>();

        Vector2 playerSize = Vector2.Scale(playerCol.size, player.lossyScale);
        Vector2 boxSize = Vector2.Scale(box.size, transform.lossyScale);

        Vector2 dir = (transform.position - player.position).normalized;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            distance = (playerSize + boxSize) / 2f + new Vector2(0.05f,0);
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
            distance = (playerSize + boxSize) / 2f + new Vector2 (0,0.05f);
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
    
}
