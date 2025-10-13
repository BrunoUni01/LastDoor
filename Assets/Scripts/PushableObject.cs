using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private float speedMultiply = 1;
    private Validador valida;
    private Transform target;
    private Rigidbody2D rb;
    private bool onCollision;
    private float distance;
    public RaycastHit2D hit;
    [SerializeField] float amplitud;
    private Vector2 direction;
    [SerializeField] bool isPuzzleTres;
    private void Awake() { rb = GetComponent<Rigidbody2D>(); onCollision = false; distance = (GetComponent<BoxCollider2D>().size.x / 2f) + 0.01f; }
    void Update()
    {
        if (onCollision) return;
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (!collision.collider.CompareTag("Player")) { direction = new Vector2(0,0); return; }
        
        onCollision = true;
        direction = collision.contacts[0].normal;
        Vector2 start = (Vector2)transform.position + distance * direction;
        RaycastHit2D hitWall = Physics2D.Raycast(start, direction, amplitud, LayerMask.GetMask("Wall"));
        if (hitWall) return; // Si hay muro, no se mueve

        // Detecta otra caja
        RaycastHit2D hitBox = Physics2D.Raycast(start, direction, amplitud, LayerMask.GetMask("Caja"));
        if (hitBox)
        {
            PushableObject otherBox = hitBox.collider.GetComponent<PushableObject>();

            // Si la otra caja no puede moverse, esta tampoco se mueve
            if (otherBox == null || !otherBox.CanMove(direction))
                return;

            // Empuja la otra caja
            otherBox.Push(direction);
        }
        rb.MovePosition(rb.position + direction * speedMultiply * Time.fixedDeltaTime);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        onCollision = false;
        rb.constraints = RigidbodyConstraints2D.None;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPuzzleTres || onCollision) return;
        if (!collision.CompareTag("Finish")) return;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        target = collision.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isPuzzleTres) return;
        if (!collision.CompareTag("Finish")) return;
        target = null;
    }
    private void OnDrawGizmos()
    {
        //Vector2 start = (Vector2)transform.position + distance * direction;
        //Debug.DrawRay(start, direction * amplitud, Color.red);
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Player")) return;
    //    Vector2 direction = collision.GetComponent<colldd>.contacts[0].normal;
    //    rb.MovePosition(rb.position + direction * speedMultiply * Time.fixedDeltaTime);
    //}
    public void Validador(Transform pos) 
    {
        target = pos.transform;
        if (onCollision) return;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }
    public void Push(Vector2 dir)
    {
        direction = dir;

        // Verificar si esta caja puede moverse
        if (HasWallInFront(direction))
            return;

        // Verificar si hay otra caja adelante
        Vector2 start = (Vector2)transform.position + distance * direction;
        RaycastHit2D hitBox = Physics2D.Raycast(start, direction, amplitud, LayerMask.GetMask("Caja"));

        if (hitBox.collider)
        {
            PushableObject nextBox = hitBox.collider.GetComponent<PushableObject>();

            // Si la otra caja no puede moverse, no la empujo
            if (nextBox != null)
            {
                if (nextBox.HasWallInFront(direction))
                    return;

                // Si puede, la empujo antes de mover esta
                nextBox.Push(direction);
            }
        }

        // Finalmente, mover esta caja
        rb.MovePosition(rb.position + direction * speedMultiply * Time.fixedDeltaTime);
    }
    private bool HasWallInFront(Vector2 dir)
    {
        Vector2 start = (Vector2)transform.position + distance * dir;
        RaycastHit2D hitWall = Physics2D.Raycast(start, dir, amplitud, LayerMask.GetMask("Wall"));
        Debug.DrawRay(start, dir * amplitud, Color.yellow);

        return hitWall.collider != null;
    }
    public bool CanMove(Vector2 dir)
    {
        Vector2 start = (Vector2)transform.position + dir * distance;

        RaycastHit2D hitWall = Physics2D.Raycast(start, dir, amplitud, LayerMask.GetMask("Wall"));
        if (hitWall) return false;

        RaycastHit2D hitBox = Physics2D.Raycast(start, dir, amplitud, LayerMask.GetMask("Caja"));
        if (hitBox)
        {
            PushableObject next = hitBox.collider.GetComponent<PushableObject>();
            if (next != null)
                return next.CanMove(dir);
        }

        return true;
    }

}
