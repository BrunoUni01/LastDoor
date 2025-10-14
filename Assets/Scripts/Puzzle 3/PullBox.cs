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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            dragging = true;
            player = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            dragging = false;
            player = null;
        }
    }
    void Pull() 
    {
        if (!dragging) return;
        if (Input.GetKey(KeyCode.R))
        {
            moveBox = true;
        }
        else 
        {
            moveBox = false;
        }
    }
    private void FixedUpdate()
    {
        Pull();
        if (!moveBox || player == null) return;

        Vector2 direction = (player.position - transform.position);
        float distance = direction.magnitude;

        // Solo moverse si el jugador se aleja más de la distancia límite
        if (distance > maxDistance)
        {
            direction.Normalize();
            Vector2 targetPos = rb.position + direction * followSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPos);
        }
    }
}
