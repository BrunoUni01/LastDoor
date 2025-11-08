using UnityEngine;

public class PullBox : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] BoxCollider2D box;
    [SerializeField] private bool dragging, inPlayer;
    private Transform player;
    public float followSpeed = 0.5f;
    [SerializeField]private PlayerMovement jugador;
    public float maxDistance = 1.2f;
    private Vector2 distance;
    private Vector2 playerColliderPos;
    private bool a = true;

    private void Awake()
    {
        inPlayer = false;
        rb = GetComponentInParent<Rigidbody2D>();

    }
    private void Start()
    {
        jugador = FindAnyObjectByType<PlayerMovement>();
        followSpeed = 0.5f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (jugador.inPull) return;
        player = collision.transform;
        dragging = false;
        inPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
        
            jugador.inPull = false;
            player = null;
            dragging = false;
            inPlayer = false;
        
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
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            dragging = false;
            inPlayer = false;
            return;
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (inPlayer)
            {
                jugador.inPull = true;
                //transform.SetParent(player);
                dragging = true;
                Vector2 dir = Direccion();
                if (dir == Vector2.zero)
                {
                    inPlayer = false;
                    return;
                }
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.gravityScale = 0f;
                //rb.constraints = RigidbodyConstraints2D.FreezeAll;
                Vector2 targetPos = playerColliderPos + dir * distance;
                rb.MovePosition(targetPos);
            }
            //else
            //{
            //    //print("a");
            //    //transform.SetParent(null);
            //    rb.bodyType = RigidbodyType2D.Dynamic;
            //    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            //    dragging = false;
            //    //inPlayer = false;
            //}
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            dragging = false;
        }
        if (!dragging) 
        {
            jugador.inPull = false;
        }
        
        

    }

    Vector2 Direccion()
    {
        CircleCollider2D playerCol = player.GetComponentInChildren<CircleCollider2D>();
        if (playerCol == null) return Vector2.zero;

        
        float playerRadius = playerCol.radius * player.lossyScale.x;

        
        Vector2 boxSize = Vector2.Scale(box.size, transform.lossyScale);

        
        playerColliderPos = (Vector2)playerCol.transform.position + playerCol.offset * player.lossyScale;

        
        Vector2 dir = ((Vector2)transform.position - playerColliderPos).normalized;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            distance = new Vector2((playerRadius + boxSize.x / 2f) + 0.05f, 0);
            if (dir.x > 0)
            {
                return Vector2.right;
            }
            else
            {
                return Vector2.left;
            }
        }
        else
        {
            distance = new Vector2(0, (playerRadius + boxSize.y / 2f) + 0.05f);
            if (dir.y > 0)
            {
                return Vector2.up;
            }
            else
            {
                return Vector2.down;
            }
        }
    }


}
