using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private float speedMultiply = 1;
    private Validador valida;
    //public Transform target;
    private Rigidbody2D rb;
    [SerializeField] private bool onCollision;
    private float distance;
    public RaycastHit2D hit;
    [SerializeField] float amplitud;
    private Vector2 direction;
    [SerializeField] bool isPuzzleTres;
    private bool isCheckingMove = false;
    private void Awake() { rb = GetComponent<Rigidbody2D>(); onCollision = false; distance = (GetComponent<BoxCollider2D>().size.x / 2f) + 0.01f; }
    private void Update()
    {
        if (onCollision)
            return;

        // Si no hay nada al frente, moverse hacia el target
        //if (!DetectarFrente(direction, out RaycastHit2D hit))
        //{
        //    //rb.MovePosition(Vector2.MoveTowards(rb.position, target.position, Time.deltaTime * speedMultiply));
        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player") && collision.gameObject.layer != 8)
            return;

        onCollision = true;
        direction = collision.contacts[0].normal;

        // Detectar si hay pared o caja al frente
        if (DetectarFrente(direction, out RaycastHit2D hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                return;

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Caja"))
            {
                PushableObject otherBox = hit.collider.GetComponent<PushableObject>();
                if (otherBox != null && otherBox.CanMove(direction))
                    otherBox.Push(direction);
                else
                    return;
            }
        }

        rb.MovePosition(rb.position + direction * speedMultiply * Time.fixedDeltaTime);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player") && collision.gameObject.layer != 8)
            return;

        onCollision = false;
        rb.constraints = RigidbodyConstraints2D.None;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPuzzleTres || onCollision) return;
        if (!collision.CompareTag("Finish")) return;

        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //target = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isPuzzleTres) return;
        if (!collision.CompareTag("Finish")) return;

        //target = null;
    }

    //  Método que hace un triple raycast dinámico al frente de la caja
    private bool DetectarFrente(Vector2 dir, out RaycastHit2D hit)
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        Vector2 scaledSize = Vector2.Scale(box.size, transform.lossyScale);

        float distance = (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) ? scaledSize.x : scaledSize.y) / 2f + 0.01f; // se adapta al ancho y alto del gameobject
        float distanceY = (scaledSize.y / 2f) * 0.9f; // un poco menos para no chocar esquinas
        Vector2 perp = new Vector2(-dir.y, dir.x);

        // Puntos de inicio del raycast (centro, arriba, abajo)
        Vector2 startCenter = (Vector2)transform.position + dir * distance;
        Vector2 startTop = (Vector2)transform.position + dir * distance + perp * distanceY;
        Vector2 startBottom = (Vector2)transform.position + dir * distance - perp * distanceY;


        RaycastHit2D center = Physics2D.Raycast(startCenter, dir, amplitud, LayerMask.GetMask("Wall", "Caja"));
        RaycastHit2D top = Physics2D.Raycast(startTop, dir, amplitud, LayerMask.GetMask("Wall", "Caja"));
        RaycastHit2D bottom = Physics2D.Raycast(startBottom, dir, amplitud, LayerMask.GetMask("Wall", "Caja"));

        // Dibuja los rayos (debug visual)
        Debug.DrawRay(startCenter, dir * amplitud, Color.red);
        Debug.DrawRay(startTop, dir * amplitud, Color.red);
        Debug.DrawRay(startBottom, dir * amplitud, Color.red);

        if (center.collider) { hit = center; return true; }
        if (top.collider) { hit = top; return true; }
        if (bottom.collider) { hit = bottom; return true; }

        hit = default;
        return false;
    }

    //  Comprueba si puede moverse (sin muro ni caja bloqueante)
    public bool CanMove(Vector2 dir)
    {
        if (isCheckingMove)
            return false;

        isCheckingMove = true;

        bool canMove = true;
        if (DetectarFrente(dir, out RaycastHit2D hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                canMove = false;

            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Caja"))
            {
                PushableObject next = hit.collider.GetComponent<PushableObject>();
                if (next != null && next.CanMove(direction))
                {
                    // Fuerza a la caja a calcular sus tres rayos antes de moverse
                    if (!next.DetectarFrente(direction, out RaycastHit2D nextHit))
                        next.Push(direction);
                }

            }
        }

        isCheckingMove = false;
        return canMove;
    }

    //  Empuja otra caja
    public void Push(Vector2 dir)
    {
        direction = dir;

        if (!CanMove(dir)) return;

        rb.MovePosition(rb.position + dir * speedMultiply * Time.fixedDeltaTime);
    }
    public void Validador(Transform pos)
    {
        //target = pos.transform;
        if (onCollision) return;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }
    private bool HasWallInFront(Vector2 dir)
    {
        Vector2 start = (Vector2)transform.position + distance * dir;
        RaycastHit2D hitWall = Physics2D.Raycast(start, dir, amplitud, LayerMask.GetMask("Wall"));
        Debug.DrawRay(start, dir * amplitud, Color.yellow);

        return hitWall.collider != null;
    }
}