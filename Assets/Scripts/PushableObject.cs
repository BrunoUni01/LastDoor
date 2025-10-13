using UnityEngine;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private float speedMultiply = 1;
    private Validador valida;
    private Transform target;
    private Rigidbody2D rb;
    private bool onCollision;
    private float distance;
    private Vector2 direction;
    [SerializeField] bool isPuzzleTres;
    private void Awake() { rb = GetComponent<Rigidbody2D>(); onCollision = false; distance = (GetComponent<BoxCollider2D>().size.x) - 0.19f; }
    void Update()
    {
        if (onCollision) return;
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        onCollision = true;
        direction = collision.contacts[0].normal;
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, distance, LayerMask.GetMask("Wall"));
        if(!hit)
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
        Debug.DrawRay(transform.position, direction * distance, Color.red);
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
}
