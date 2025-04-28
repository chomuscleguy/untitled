using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    public static Managers Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Managers>();
            }
            return _instance;
        }
    }

    public GameManager gameManager;
    public DataManager dataManager;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        gameManager = GetComponentInChildren<GameManager>();
        dataManager = GetComponentInChildren<DataManager>();
    }
}
