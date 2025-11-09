using UnityEngine;

public class AnimacionInicio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void EntrarBotones() 
    {
        ani.SetTrigger("Botones");
    }

    public void EntrarBucle() 
    {
        ani.SetTrigger("Bucle");
    }
}
