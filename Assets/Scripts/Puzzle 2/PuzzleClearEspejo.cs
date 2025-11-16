using UnityEngine;

public class PuzzleClearEspejo : MonoBehaviour
{
    private Move green;
    private MirrorMove pink;
    public bool puzzleclear;
    public GameObject puzzle2;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private GameObject interactor;
    [SerializeField] private EnterPuzzle EnterPuzzle;
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
            EnterPuzzle.enabled = false;
            //interactor.SetActive(false);
            puzzle2.SetActive(false);
            player.gameObject.SetActive(true);
        }
    }
}
