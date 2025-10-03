using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerBotones : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    //public int scene;
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
        Time.timeScale = 1f;
    }

}
