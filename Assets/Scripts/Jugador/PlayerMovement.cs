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
        if (Input.GetKeyDown(KeyCode.LeftShift))
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

        if (inputX != 0)
            lastDirectionX = inputX;
        if (inputY != 0)
        {
            
            lastDirectionY = inputY;
        }
        //else lastDirectionY = 0;

            Vector2 movimiento = new Vector2(inputX, inputY);
        body.linearVelocity = movimiento.normalized * currentSpeed;

        if (!inTouchable)
        {
            if (inputX < 0 && inputY < 0)
                anim.SetTrigger("caminaIzq");
            else if (inputX < 0 && inputY > 0)
                anim.SetTrigger("caminaIzq");
            else if (inputX < 0 && inputY == 0)
                anim.SetTrigger("caminaIzq");
            else if (inputY < 0 && inputX == 0)
                anim.SetTrigger("caminaIzq");
            else if (inputX > 0 && inputY < 0)
                anim.SetTrigger("caminaDer");
            else if (inputX > 0 && inputY > 0)
                anim.SetTrigger("caminaDer");
            else if (inputX > 0 && inputY == 0)
                anim.SetTrigger("caminaDer");
            else if (inputY > 0 && inputX == 0)
                anim.SetTrigger("caminaDer");




            //if (inputX == 0 && inputY == 0 && lastDirectionX < 0)
            //{
            //    anim.SetTrigger("IddleIzq");
            //}
            //else if (inputX == 0 && inputY == 0 && lastDirectionX > 0)
            //{
            //    anim.SetTrigger("IddleDer");
            //}
            if (inputX == 0 && inputY == 0)
            {
                if (lastDirectionX < 0)
                    anim.SetTrigger("IddleIzq");
                else if (lastDirectionX > 0)
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
        inDash = true;
        startDash = true;
        inTouchable = true;
        currentSpeed *= dashForce;
        anim.ResetTrigger("caminaIzq");
        anim.ResetTrigger("caminaDer");
        anim.ResetTrigger("IddleIzq");
        anim.ResetTrigger("IddleDer");
        if (lastDirectionX < 0)
        {
            //anim.ResetTrigger("caminaIzq");
            anim.SetTrigger("DashIzq");
        }
        if (lastDirectionX > 0)
        {
            //anim.ResetTrigger("caminaDer");
            anim.SetTrigger("DashDer");
        }
        if (lastDirectionY > 0) 
        {
            //anim.ResetTrigger("caminaDer");
            anim.SetTrigger("DashDer");
        }
        if (lastDirectionY < 0) 
        {
            //anim.ResetTrigger("caminaIzq");
            anim.SetTrigger("DashIzq");
        }
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
