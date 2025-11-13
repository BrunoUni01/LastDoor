using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RoomFade fade;
    private bool inFade;
    private bool entroFade;
    void Start()
    {
        fade = FindAnyObjectByType<RoomFade>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            inFade = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inFade && !entroFade) 
        {
            entroFade = true;
            fade.FadeOut();
        }
        if (entroFade) 
        {
            if (fade.getFadeout()())
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
