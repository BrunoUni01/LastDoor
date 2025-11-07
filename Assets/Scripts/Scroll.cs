using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;

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
    [SerializeField] float tiempoBarra;
    private GameManagerBotones gameOver;
    [SerializeField] SpriteRenderer sprite;
    private Color colorInicio;
    private Color colorMedio;
    private Color colorMedioFinal;
    private Color colorFinal;
    float[] tiempos;


    //[SerializeField] private AnimationCurve curveSpeed;

    public float getFill { get => t / tiempo; }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();    
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
        GeneracionDeTiempos();
        //ColorActual();

    }

    void GeneracionDeTiempos() 
    {
        tiempoBarra = t / tiempo * 100;
        
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
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(b.y, camara.position.y , t / tiempo/2.2f), transform.position.z);
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

    //void ColorActual() 
    //{
    //    colorInicio = sprite.color;
    //    if (tiempoBarra >= 20f)
    //    {
    //        StartCoroutine(nameof(FasesScroll));
    //        if (tiempoBarra < 50f)
    //        {
    //            colorInicio.a = 0.1f;
    //            colorMedio.a = 0.15f;
    //            colorMedioFinal.a = 0.2f;
    //            colorFinal.a = 0.25f;
    //        }
    //        else if (tiempoBarra >= 50f && tiempoBarra < 75f)
    //        {
    //            colorInicio.a = 0.15f;
    //            colorMedio.a = 0.2f;
    //            colorMedioFinal.a = 0.25f;
    //            colorFinal.a = 0.3f;
    //        }
    //        else if (tiempoBarra >= 75f && tiempoBarra < 85f)
    //        {
    //            colorInicio.a = 0.2f;
    //            colorMedio.a = 0.25f;
    //            colorMedioFinal.a = 0.3f;
    //            colorFinal.a = 0.35f;
    //        }
    //        else if (tiempoBarra >= 85f)
    //        {
    //            colorInicio.a = 0.4f;
    //            colorMedio.a = 0.45f;
    //            colorMedioFinal.a = 0.5f;
    //            colorFinal.a = 0.55f;
    //        }
    //    }
    //    else 
    //    {
    //        StopCoroutine(nameof(FasesScroll));
    //    }
    //}
    //private IEnumerator FasesScroll() 
    //{
    //    // 20 -> 70 -> 85 -> 100
    //    ColorActual();
    //    if (tiempoBarra < 20f) yield break;
    //    sprite.color = colorInicio;
    //    sprite.enabled = true;
    //    yield return new WaitForSeconds(0.15f);
    //    sprite.enabled = false;
    //    yield return new WaitForSeconds(0.4f);
    //    sprite.color = colorMedio;
    //    sprite.enabled = true;
    //    yield return new WaitForSeconds(0.1f);
    //    sprite.enabled = false;
    //    yield return new WaitForSeconds(0.2f);
    //    sprite.color = colorMedioFinal;
    //    sprite.enabled = true;
    //    yield return new WaitForSeconds(0.1f);
    //    sprite.enabled = false;
    //    yield return new WaitForSeconds(0.25f);
    //    sprite.color = colorFinal;
    //    sprite.enabled = true;

    //}
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