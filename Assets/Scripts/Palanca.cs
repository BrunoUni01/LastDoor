using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(BoxCollider2D))]
public class Palanca : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private bool activado;
    [SerializeField] private SpriteRenderer indicador;
    [SerializeField] private Light2D luz;
    public bool Activado { get => activado;  set => activado = value; }




    void Start()
    {
        luz = GetComponentInChildren<Light2D>();
        activado = false;
        indicador = transform.GetChild(0).GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (activado)
        {
            luz.enabled = true;
            indicador.color = Color.green;
        }
        else 
        {
            luz.enabled= false;
            indicador.color= Color.red;
        }
        
    }
    
}
