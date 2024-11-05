using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameLogic gameLogic;
    public MapGenerator mapGenerator;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameLogic.Initialize(mapGenerator);
    }

    public void GameOver()
    {
        Debug.Log("Game Over! You clicked on a mine.");       
    }
}
