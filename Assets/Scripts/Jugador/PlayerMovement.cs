using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [Header("Dash")]
    [SerializeField] private float dashForce;
    [SerializeField] private bool inDash;
    [HideInInspector] public bool inTouchable;
    [SerializeField] private float dashDistance;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float cooldown;

    [Header("Movimiento Lineal")]
    [SerializeField] public float currentSpeed;
    [SerializeField] private Palanca palancaActual;
    private bool puedeActivar;
    public bool canMove;
    [SerializeField] private int inputCounter = 0;
    private bool isStuck;

    [Header("Comprobaciones")]
    [HideInInspector] public bool inPull;

    [Header("Raycasts")]
    [SerializeField] private Transform inicioRaycastSuelo;
    [SerializeField] private float distanciaRayoSuelo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
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
        if (canMove && !isStuck)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 movimiento = new Vector2(x, y);
            body.linearVelocity = movimiento.normalized * currentSpeed;
            //ActivarPalanca();
        }
        if (isStuck) Stuck();
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
        inTouchable = true;
        currentSpeed *= dashForce;
        Invoke("AfterDash", dashDistance / 10);
        Invoke("ResetDash", cooldown);


    }
    void AfterDash()
    {
        currentSpeed = normalSpeed;
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
            if(inputCounter == 30)
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
        if (collision.CompareTag("Pegamento"))
        {
            isStuck = true;
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
