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
        if (escombros > 0)
        {
            //unlock
            enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Escombros")) return;
        escombros += 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Escombros")) return;
        escombros -= 1;
    }
}
