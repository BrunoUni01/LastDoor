using UnityEngine;
using UnityEngine.UI;

public class HUD_barra : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float height;
    [SerializeField] Image sprite;
    [SerializeField] Scroll current;
    void Start()
    {
        sprite = GetComponent<Image>();
        current = FindAnyObjectByType<Scroll>();
        height = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //sprite.fillAmount = height;
        BarraFill();
    }
    void BarraFill() 
    {
        sprite.fillAmount = current.getFill;
    }
}
