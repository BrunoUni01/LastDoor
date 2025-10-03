using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject MenuPausa;
    public static bool enpausa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enpausa)
            {
                Resumir();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        enpausa = true;
    }

    public void Resumir()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        enpausa = false;
    }
}
