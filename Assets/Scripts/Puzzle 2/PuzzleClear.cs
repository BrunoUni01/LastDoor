using UnityEngine;

public class PuzzleClear : MonoBehaviour
{
    private Move green;
    private MirrorMove pink;
    private bool puzzleclear;
    public GameObject puzzle2;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private GameObject interactor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        green = FindFirstObjectByType<Move>();
        pink = FindFirstObjectByType<MirrorMove>();
        puzzleclear = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        LevelClear();
    }

    private void LevelClear()
    {
        if (green.clear == true && pink.clear == true)
        {
            interactor.tag = "Finish";
            puzzleclear = true;
            //interactor.SetActive(false);
            puzzle2.SetActive(false);
            player.gameObject.SetActive(true);
        }
    }
}
