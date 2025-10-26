using UnityEngine;

public class ControladorPausa : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool enpausa;
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
