using UnityEngine;

public class Escombros : MonoBehaviour
{
    [SerializeField] int escombros;

    private void Update()
    {
        CerraPuzzle();
    }
    private void CerraPuzzle()
    {
        if (escombros <= 0)
        {
            //unlock
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Escombros")) return;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Escombros")) return;
        Destroy(collision.gameObject);
        escombros -= 1;
        
    }
    public bool FinEscombros() 
    {
        return escombros <= 0;
    }
}
