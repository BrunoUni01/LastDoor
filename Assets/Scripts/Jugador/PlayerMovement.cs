using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [Header("Dash")]
    [SerializeField] private float dashForce;
    [SerializeField] private bool inDash, startDash;
     public bool inTouchable;
    [SerializeField] private float dashDistance;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float cooldown;

    [Header("Movimiento Lineal")]
    [SerializeField] public float currentSpeed;
    private Vector2 lastDirection;
    [SerializeField] private Palanca palancaActual;
    private float inputX, inputY, lastDirectionX, lastDirectionY;
    private bool puedeActivar;
    public bool canMove;
    [SerializeField] private int inputCounter = 0;
    [SerializeField] private bool isStuck;

    [Header("Comprobaciones")]
    [HideInInspector] public bool inPull;

    [Header("Raycasts")]
    [SerializeField] private Transform inicioRaycastSuelo;
    [SerializeField] private float distanciaRayoSuelo;

    [Header("Animaciones")]
    [SerializeField] private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        anim = GetComponent<Animator>();
        inPull = false;
        canMove = true;
        isStuck = false;
        lastDirection = Vector2.right;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        normalSpeed = currentSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        //Vector2 movimiento = new Vector2(x, y);
        //body.linearVelocity = movimiento.normalized * currentSpeed;
        //ActivarPalanca();

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    if(!inDash)
        //    Dash();
        //}
        if (canMove && !isStuck)
        {
            movimiento();
        }
        if (isStuck) Stuck();
        ActivarPalanca();
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isStuck)
        {
            if (!inDash)
                Dash();
        }
        if (isStuck) TrampaPegamento();
    }
    private void FixedUpdate()
    {
        
    }
    private void movimiento() 
    {
        if (!inTouchable) // Evita que cambie de dirección mientras esta en dash
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");
        }

        if (inputX != 0 || inputY != 0)
        {
            lastDirection = new Vector2(inputX, inputY);
        }


        //else lastDirectionY = 0;

        Vector2 movimiento = new Vector2(inputX, inputY);
        body.linearVelocity = movimiento.normalized * currentSpeed;

        if (!inTouchable)
        {
            if (inputX != 0 || inputY != 0) // caminando
            {
                Vector2 dir = lastDirection;

                if (dir.x < 0 && dir.y == 0)
                    anim.SetTrigger("caminaIzq");
                else if (dir.x > 0 && dir.y == 0)
                    anim.SetTrigger("caminaDer");
                else if (dir.y > 0 && dir.x == 0)
                    anim.SetTrigger("caminaDer");
                else if (dir.y < 0 && dir.x == 0)
                    anim.SetTrigger("caminaIzq");

                else if (dir.x < 0 && dir.y > 0)
                    anim.SetTrigger("caminaIzq");
                else if (dir.x > 0 && dir.y > 0)
                    anim.SetTrigger("caminaDer");
                else if (dir.x < 0 && dir.y < 0)
                    anim.SetTrigger("caminaIzq");
                else if (dir.x > 0 && dir.y < 0)
                    anim.SetTrigger("caminaDer");
            }
            else // idle
            {
                Vector2 dir = lastDirection;

                if (dir.x < 0 && dir.y == 0)
                    anim.SetTrigger("IddleIzq");
                else if (dir.x > 0 && dir.y == 0)
                    anim.SetTrigger("IddleDer");
                else if (dir.y > 0 && dir.x == 0)
                    anim.SetTrigger("IddleDer");
                else if (dir.y < 0 && dir.x == 0)
                    anim.SetTrigger("IddleIzq");

                else if (dir.x < 0 && dir.y > 0)
                    anim.SetTrigger("IddleIzq");
                else if (dir.x > 0 && dir.y > 0)
                    anim.SetTrigger("IddleDer");
                else if (dir.x < 0 && dir.y < 0)
                    anim.SetTrigger("IddleIzq");
                else if (dir.x > 0 && dir.y < 0)
                    anim.SetTrigger("IddleDer");
            }

        }
    }
    public bool RayoSuelo(LayerMask current) 
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)inicioRaycastSuelo.position, Vector2.down, distanciaRayoSuelo, current);
        return hit.collider;

    }
    public void GameOver() 
    {
        body.linearVelocity = new Vector2 (0, 0);
        enabled = false;
    }
    void Dash()
    {
        if (inputX == 0 && inputY == 0) return;
        inTouchable = true;
        inDash = true;
        startDash = true;
        anim.ResetTrigger("caminaIzq");
        anim.ResetTrigger("caminaDer");
        anim.ResetTrigger("IddleIzq");
        anim.ResetTrigger("IddleDer");


        Vector2 dir = lastDirection;

        if (dir.x < 0 && dir.y == 0)
            anim.SetTrigger("DashIzq");
        else if (dir.x > 0 && dir.y == 0)
            anim.SetTrigger("DashDer");
        else if (dir.y > 0 && dir.x == 0)
            anim.SetTrigger("DashDer");
        else if (dir.y < 0 && dir.x == 0)
            anim.SetTrigger("DashIzq");

        else if (dir.x < 0 && dir.y > 0)
            anim.SetTrigger("DashIzq");
        else if (dir.x > 0 && dir.y > 0)
            anim.SetTrigger("DashDer");
        else if (dir.x < 0 && dir.y < 0)
            anim.SetTrigger("DashIzq");
        else if (dir.x > 0 && dir.y < 0)
            anim.SetTrigger("DashDer");

        currentSpeed *= dashForce;
        Invoke("AfterDash", dashDistance / 10);
        Invoke("ResetDash", cooldown);


    }
    void AfterDash()
    {
        currentSpeed = normalSpeed;
        startDash = false;
        //body.linearVelocity = new Vector2(0, 0);
        inTouchable = false;
    }
    void ResetDash() 
    {
        inDash = false;
    }
    void ActivarPalanca() 
    {
        if (puedeActivar) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Debug.Log("Esta intenando activar!");
                EventManager.ReportDiscovery("Puzzle_Palancas");
                palancaActual.Activado = true;
            }
        }   
    }

    void TrampaPegamento()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inputCounter++;
            }
            if(inputCounter == 15)
            {
                isStuck = false;
            }
    }
    public void ActivarStuck() 
    {
        isStuck = true;
    }
    public void DesactivarStuck()
    {
        isStuck = false;
    }

    void Stuck()
    {
        //anim.ResetTrigger("caminaIzq");
        //anim.ResetTrigger("caminaDer");
        //anim.ResetTrigger("IddleIzq");
        //anim.ResetTrigger("IddleDer");
        //anim.SetTrigger("DashDer");
        //anim.SetTrigger("DashIzq");
        body.linearVelocity = new Vector2(0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Palanca"))
        {
            puedeActivar = true;
            palancaActual = collision.GetComponent<Palanca>();
        }
        if (!startDash)
        {
            if (collision.CompareTag("Pegamento"))
            {
                isStuck = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Palanca"))
        {
            puedeActivar = false;
            palancaActual = null;
        }
        if (collision.CompareTag("Pegamento"))
        {
            inputCounter = 0;
            isStuck = false;
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(inicioRaycastSuelo.position, Vector3.down * distanciaRayoSuelo, Color.yellow);
    }
}
