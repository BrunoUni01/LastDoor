using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float delayPerSecond = 3f;
    private bool fadeIn;
    private bool iniciaFadeIn;
    private bool fadeOut;
    private bool iniciaFadeOut;



    private void Awake()
    {
        iniciaFadeIn = true;
        iniciaFadeOut = false;
    }
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        fadeIn = true;
        canvasGroup.alpha = 1f;
    }
    public void Fadein() 
    {
        if (fadeOut) return;
        fadeIn = true;
    }
    public void FadeOut() 
    {
        if (fadeIn) return;
        fadeOut = true;
    }
    //public void IniciaFadeIn() 
    //{
    //    iniciaFadeIn = true;
    //}
    //public void IniciaFadeOut()
    //{
    //    iniciaFadeOut = true;
    //}
    public System.Func<bool> getFadeout() 
    {
        return () => !fadeOut;
    }
    public System.Func<bool> getFadein()
    {
        return () => !fadeIn;
    }
    private void Update()
    {
        if (fadeIn)
        {
            canvasGroup.alpha -= Time.deltaTime / delayPerSecond;
            canvasGroup.alpha = Mathf.Clamp(canvasGroup.alpha, 0f, 1f);
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                fadeIn = false;

            }
        }
        if (fadeOut)
        {
            canvasGroup.alpha += Time.deltaTime / delayPerSecond;
            canvasGroup.alpha = Mathf.Clamp(canvasGroup.alpha, 0f, 1f);
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
                fadeOut = false;
            }
            
        }
    }
}
