using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform spawn;
    public int codigo;
    public bool activado;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activado = false;
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Respawn()
    {
        transform.position = spawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (codigo == -1) 
        {
            Color a = new Color(0.796f, 0.690f, 0.129f);
            sprite.color = a;   
        }
    }

    public void DestroyKey()
    {
        Destroy(gameObject);
    }
}