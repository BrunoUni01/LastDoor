using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI display;
    public int score;
    [SerializeField] Scroll current;
    private void Start()
    {
        display = FindFirstObjectByType<TextMeshProUGUI>();
    }
    public void ActualizarScroll(Scroll actual)
    {
        current = actual;   
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            current.ColisionObjeto(collision.gameObject.GetComponent<Hazard>().value);
            Destroy(collision.gameObject);
            int value = Math.Truncate(collision.gameObject.GetComponent<Hazard>().value).ConvertTo<int>();
            score += value;
            display.SetText(score.ToString());
            
        }
        else if (collision.CompareTag("Points"))
        {
            current.ColisionObjeto(collision.gameObject.GetComponent<Collectable>().value);
            Destroy(collision.gameObject);
            int value = Math.Truncate(collision.gameObject.GetComponent<Collectable>().value).ConvertTo<int>(); // 2.5 -> 2 -> (float) -> int
            score += value;
            display.SetText(score.ToString());
            
        }
    }

}
