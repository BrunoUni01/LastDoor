using UnityEngine;

public class Control_Cara_Cerdo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform inicio;
    [SerializeField] Transform final;
    [SerializeField] HUD_barra barra;
    void Start()
    {
        barra = FindAnyObjectByType<HUD_barra>();
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }
    private void Comportamiento() 
    {
        transform.position = new Vector3 (inicio.position.x, Mathf.Lerp(inicio.position.y, final.position.y, barra.getScroll().getFill), inicio.position.z);
    }
}
