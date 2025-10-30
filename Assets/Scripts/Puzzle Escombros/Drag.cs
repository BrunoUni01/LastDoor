using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private bool _isActive;
    private void Update()
    {
        if (!_isActive) return;
        print("Si funciona la funcion");
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldPosition + _offset;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("aaaaaa");
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _offset = (Vector2)transform.position - worldPosition;
        _isActive = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        print("bbbbb");
        _isActive = false;
    }
}
