using UnityEngine;

public class PushBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D body;
    Vector2 dir;
    bool inCollision;
    bool stayCollision;
    bool exitCollision;
    [SerializeField] private float fuerza;
    [SerializeField] private float desaceleracion;
    [SerializeField] private float velocidadMinima;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        inCollision = false;
        stayCollision = false;
        exitCollision = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        dir = collision.contacts[0].normal;
        inCollision = true;
        exitCollision = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        inCollision = false;
        stayCollision = false;
        exitCollision = true;
    }
    void Desacelerar() 
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation; 
        if (inCollision && !stayCollision) 
        {
            float fuerzaReal = fuerza / body.mass;
            body.AddForce(dir * fuerzaReal, ForceMode2D.Impulse);
            stayCollision = true;
        }
        if (exitCollision) 
        {
            if (body.linearVelocity.magnitude > 0f)
            {
                // Desacelera la velocidad suavemente
                body.linearVelocity = Vector2.Lerp(body.linearVelocity, Vector2.zero, desaceleracion * Time.fixedDeltaTime);

                // Si ya casi no se mueve, detenerla por completo (evita que "patine")
                if (body.linearVelocity.magnitude < velocidadMinima)
                    body.linearVelocity = Vector2.zero;
            }
        }
    }
}
