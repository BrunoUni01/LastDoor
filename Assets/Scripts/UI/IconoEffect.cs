using UnityEngine;

public class IconoEffect : MonoBehaviour
{
    [SerializeField] RectTransform target; // El cuadrado o imagen que cambiará de tamaño
    [SerializeField] float minSize = 20f;  // Tamaño mínimo
    [SerializeField] float maxSize = 40f;  // Tamaño máximo
    [SerializeField] float speed = 2f;     // Qué tan rápido "late"

    private Vector2 originalSize;

    void Start()
    {
        if (target == null)
            target = GetComponent<RectTransform>();

        originalSize = target.sizeDelta;
    }

    void Update()
    {
        // Valor oscilante entre 0 y 1
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;

        // Calcula el tamaño interpolando entre min y max
        float newSize = Mathf.Lerp(minSize, maxSize, t);

        // Aplica el nuevo tamaño (manteniendo el aspecto cuadrado)
        target.sizeDelta = new Vector2(newSize, newSize);
    }
}
