using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockerByLevel : MonoBehaviour
{

    public string sceneName;

    private void Start()
    {
        
        sceneName = SceneManager.GetActiveScene().name;

    }

    public void CheckSceneNameAndSetUnlockPref()
    {
        switch (sceneName)
        {

            case "Level1Meadow":
                PlayerPrefs.SetInt("UnlockedLevel1", 1);
                PlayerPrefs.Save();
                break;
            case "Level2Meadow":
                PlayerPrefs.SetInt("UnlockedLevel2", 1);
                PlayerPrefs.Save();
                break;
            case "Level3Door":
                PlayerPrefs.SetInt("UnlockedLevel3", 1);
                PlayerPrefs.Save();
                break;
            case "Level4Door":
                PlayerPrefs.SetInt("UnlockedLevel4", 1);
                PlayerPrefs.Save();
                break;
            case "Level5Castle":
                PlayerPrefs.SetInt("UnlockedLevel5", 1);
                PlayerPrefs.Save();
                break;
            case "Level6Castle":
                Debug.Log("Game Completed!");
                break;


            default:
                break;
        }
    }

}
