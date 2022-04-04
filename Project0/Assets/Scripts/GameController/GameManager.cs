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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeletePlayerPrefs();
        }
    }

    public void DeletePlayerPrefs()
    {
        Debug.Log("Los datos fueron borrados!");
        PlayerPrefs.DeleteAll();
    }

}
