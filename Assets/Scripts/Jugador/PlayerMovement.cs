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
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        normalSpeed = currentSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 movimiento = new Vector2(x, y);
        body.linearVelocity = movimiento.normalized * currentSpeed;
        ActivarPalanca();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(!inDash)
            Dash();
        }
       
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Palanca"))
        {
            puedeActivar = true;
            palancaActual = collision.GetComponent<Palanca>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Palanca"))
        {
            puedeActivar = false;
            palancaActual = null;
        }
    }
}
