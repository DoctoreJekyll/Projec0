using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);

    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// Aqui empiezan los stats y métodos para el cargado y guardado de valores del jugador
    /// </summary>
    /// Playerprefs variables
    public int gameGold;
    public float playerLifeManager;
    public float playerAttackManager;
    public int playerLevel;
    //Playerprefs keys
    public string goldKey = "Gold";
    public string playerLifeKey = "Life";
    public string playerAttackKey = "Attack";
    public string playerLevelKey = "Level";


    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        PlayerInitStats();
    }

    public void PlayerInitStats()
    {
        playerLifeManager = 100f;
        playerAttackManager = 20;
        playerLevel = 1;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("El oro del jugador es: " + gameGold);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameGold++;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeletePlayerPrefs();
        }
    }


    public void SaveGold()
    {
        Debug.Log("GameIsSaved!");
        PlayerPrefs.SetInt(goldKey, gameGold);
        PlayerPrefs.Save();
    }

    public void SavePlayerStats()//Guarda el daño de ataque y la vida del jugador
    {
        PlayerPrefs.SetFloat(playerLifeKey, playerLifeManager);
        PlayerPrefs.SetFloat(playerAttackKey, playerAttackManager);
        PlayerPrefs.SetInt(playerLevelKey, playerLevel);
        PlayerPrefs.Save();
    }


    public void SaveGame()
    {
        SaveGold();
        SavePlayerStats();
    }

    public void LoadGold()
    {
        Debug.Log("Game is loaded!");
        gameGold = PlayerPrefs.GetInt(goldKey, gameGold);

    }

    public void LoadPlayerStats()//Carga el daño de ataque y la vida del jugador
    {
        playerLifeManager = PlayerPrefs.GetFloat(playerLifeKey, playerLifeManager);
        playerAttackManager = PlayerPrefs.GetFloat(playerAttackKey, playerAttackManager);
        playerLevel = PlayerPrefs.GetInt(playerLevelKey, playerLevel);
    }

    public void LoadGame()
    {
        LoadGold();
        LoadPlayerStats();
    }


    public void AddGold(int gold)
    {
        gameGold = gameGold + gold;
    }

    public void DeletePlayerPrefs()
    {
        Debug.Log("Los datos fueron borrados!");
        PlayerPrefs.DeleteAll();
    }

}
