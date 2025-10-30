using UnityEngine;

public class SpriteRanObj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer render;
    void Start()
    {

        render = GetComponent<SpriteRenderer>();
        if(render != null)
        render.sprite = sprites[RandomSprites()];
    }
    int RandomSprites() 
    {
        
        return Random.Range(0, sprites.Length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
