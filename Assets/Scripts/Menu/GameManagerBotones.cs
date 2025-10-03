using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerBotones : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    [HideInInspector] public PlayerInteraction player;
    //public int scene;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerInteraction>();
    }
    public void SceneName(int scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }
    public void GameOut() 
    {
        Application.Quit();
    }
    public void Resumir()
    {
        menuPausa.SetActive(false);
        player.enpausa = false;
        Time.timeScale = 1f;
    }

}
