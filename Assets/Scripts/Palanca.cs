using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Palanca : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private bool activado;
    [SerializeField] private SpriteRenderer indicador;
    public bool Activado { get => activado;  set => activado = value; }




    void Start()
    {
        activado = false;
        indicador = transform.GetChild(0).GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (activado)
        {
            indicador.color = Color.green;
        }
        else 
        {
            indicador.color= Color.red;
        }
        
    }
    
}
