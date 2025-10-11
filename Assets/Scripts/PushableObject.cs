using UnityEngine;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private float speedMultiply = 1;
    private Validador valida;
    private Transform target;
    private Rigidbody2D rb;
    [SerializeField] bool isPuzzleTres;
    private void Awake() => rb = GetComponent<Rigidbody2D>();
    void Update()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        Vector2 direction = collision.contacts[0].normal;
        rb.MovePosition(rb.position + direction * speedMultiply * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPuzzleTres) return;
        if (!collision.CompareTag("Finish")) return;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        target = collision.transform;
    }
    public void Validador(Transform pos) 
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        target = pos.transform;
    }
}
