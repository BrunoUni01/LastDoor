using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Scroll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //[SerializeField] float hSize;
    BoxCollider2D a;
    Vector3 b;
    private ScrollManager manager;
    [SerializeField] Transform camara;
    [SerializeField] float t;
    [SerializeField] float tiempo;
    [SerializeField] bool playerIn;
    [SerializeField] float mult;
    [SerializeField] float cooldown;
    private GameManagerBotones gameOver;
    //[SerializeField] private AnimationCurve curveSpeed;


    void Start()
    {
        gameOver = FindFirstObjectByType<GameManagerBotones>();
        manager = FindFirstObjectByType<ScrollManager>();
        a = GetComponent<BoxCollider2D>();
       // camara = FindFirstObjectByType<Camera>().GetComponent<Transform>();
        b = new Vector3(camara.position.x, camara.position.y - (a.bounds.size.y), camara.position.z);
        t = 0;
        playerIn = true;
        cooldown = 0;
        mult = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ejecutar()) return;
        Ejecucion();
        
    }

    void Ejecucion() 
    {
        
        if (mult != 1) 
        {
            cooldown -= Time.deltaTime;
            
        }
        Mathf.Clamp(cooldown, 0, 15);
        if (cooldown <= 0) mult = 1;

        Mathf.Clamp(t, -10, tiempo);
        t += Time.deltaTime * mult;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(b.y, camara.position.y, t / tiempo), transform.position.z);
        Perder();
    }
    public void SetEjecucion(bool res) 
    {
        playerIn = res;
    }
    private void Perder() 
    {
        if (t / tiempo >= 1) 
        {
            gameOver.SceneName(3);
        }
    }

    public void ColisionObjeto(float value) 
    {
        if (value < 0)
        {
            t += value;
            return;
        }
        mult = value;
        cooldown += value;
        //t += value;
    }
    bool Ejecutar() => playerIn;
}

        //hSize = a.bounds.size.y;
        //Debug.Log($"el alto del bloque es: {hSize}");
        //Debug.Log("la posicion inicial es: " + b.y);
        
        //transform.Translate(Vector3.up * Time.deltaTime);
        //if (transform.position.y - b.y >= hSize) 
        //{
        //    transform.position = b;
        //}
        //a = GetComponent<BoxCollider2D>();
        //hSize = a.bounds.size.y;
        //Debug.Log($"el alto del bloque es: {hSize}");