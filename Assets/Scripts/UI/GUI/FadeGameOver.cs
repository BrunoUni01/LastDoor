using UnityEngine;
using System.Collections;

public class FadeGameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CanvasGroup _fade; // 1
    [SerializeField] private float tiempo;
    private float t;
    private void Awake()
    {
        _fade = gameObject.GetComponent<CanvasGroup>();
    }
    void Aclarar() 
    {
        t += Time.deltaTime / tiempo;
        _fade.alpha = Mathf.Lerp(1f, 0f, t);
    }
    
    // Update is called once per frame
    void Update()
    {
        Aclarar();
    }
}
