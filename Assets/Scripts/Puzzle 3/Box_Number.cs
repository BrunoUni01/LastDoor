using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Box_Number : MonoBehaviour
{
    public int numero;
    [SerializeField] private TextMeshPro _textMeshPro;
    public void AsignarTexto() 
    {
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _textMeshPro.text = $"{numero}";
    }
}
