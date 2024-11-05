using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Sprite emptySprite; 
    public Sprite mineSprite; 
    public Sprite flagSprite; 
    public Sprite closeBlockSprite; 
    public Sprite[] numberSprites; 

    private static ResourceManager _instance;

    public static ResourceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ResourceManager>();
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

    public Sprite GetNumberSprite(int number)
    {
        if (number > 0 && number <= numberSprites.Length)
        {
            return numberSprites[number - 1];
        }
        return null;
    }
}
