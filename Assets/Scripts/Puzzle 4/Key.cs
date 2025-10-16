using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform spawn;
    public int codigo;
    public bool activado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activado = false;
    }
    public void Respawn() 
    {
        transform.position = spawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyKey() 
    {
        Destroy(gameObject);
    }
}
