using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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

    public int gameGold;
    public string goldKey = "Gold";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("El oro del jugador es: " + gameGold);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameGold++;
        }
    }


    public void SaveGold()
    {
        PlayerPrefs.SetInt(goldKey, gameGold);
        PlayerPrefs.Save();
    }


    public void LoadGold()
    {
        int gold = PlayerPrefs.GetInt(goldKey, gameGold);
        gameGold = gold;
    }





}
