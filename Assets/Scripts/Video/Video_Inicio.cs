using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video_Inicio : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject textoSkip;
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (video.time >= 15f) 
        {
            textoSkip.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                SceneManager.LoadScene(1);
            }
        }
        if (!video.isPlaying && video.time >= 30f) 
        {
            SceneManager.LoadScene(1);
        }
    }
}
