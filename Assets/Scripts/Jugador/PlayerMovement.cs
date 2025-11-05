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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.G)) 
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
}
