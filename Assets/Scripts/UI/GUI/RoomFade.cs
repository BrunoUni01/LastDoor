using UnityEngine;

public class RoomFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float delayPerSecond = 3f;
    private bool fadeIn;
    private bool fadeOut;



    private void Awake()
    {

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
        fadeOut = false;
    }
    private void Update()
    {
        if (fadeIn)
        {
            canvasGroup.alpha -= Time.deltaTime / delayPerSecond;
            canvasGroup.alpha = Mathf.Clamp(canvasGroup.alpha, 0f, 1f); 
            if (canvasGroup.alpha < 0)
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
