using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _offset;
    private bool _isActive;
    private void Update()
    {
        if (!_isActive) return;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldPosition + _offset;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _offset = (Vector2)transform.position - worldPosition;
        _isActive = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _isActive = false;
    }
}
