using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUnlocked : MonoBehaviour
{
    [SerializeField] private GameObject[] lockedPanel;
    [SerializeField] private bool unlockLevel1;
    [SerializeField] private bool unlockLevel2;
    [SerializeField] private bool unlockLevel3;
    [SerializeField] private bool unlockLevel4;
    [SerializeField] private bool unlockLevel5;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockedLevel1"))
        {
            PlayerPrefs.SetInt("UnlockedLevel1", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("UnlockedLevel2"))
        {
            PlayerPrefs.SetInt("UnlockedLevel2", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("UnlockedLevel3"))
        {
            PlayerPrefs.SetInt("UnlockedLevel3", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("UnlockedLevel4"))
        {
            PlayerPrefs.SetInt("UnlockedLevel4", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("UnlockedLevel5"))
        {
            PlayerPrefs.SetInt("UnlockedLevel5", 0);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        UnlockLevel();
        Debug.Log("unlocked 1 value: " + PlayerPrefs.GetInt("UnlockedLevel1"));
        Debug.Log("unlocked 2 value: " + PlayerPrefs.GetInt("UnlockedLevel2"));
        Debug.Log("unlocked 3 value: " + PlayerPrefs.GetInt("UnlockedLevel3"));
        Debug.Log("unlocked 4 value: " + PlayerPrefs.GetInt("UnlockedLevel4"));
        Debug.Log("unlocked 5 value: " + PlayerPrefs.GetInt("UnlockedLevel5"));
    }

    private void UnlockLevel()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel1") == 1)
        {
            lockedPanel[0].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevel2") == 1)
        {
            lockedPanel[0].SetActive(false);
            lockedPanel[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevel3") == 1)
        {
            lockedPanel[0].SetActive(false);
            lockedPanel[1].SetActive(false);
            lockedPanel[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevel4") == 1)
        {
            lockedPanel[0].SetActive(false);
            lockedPanel[1].SetActive(false);
            lockedPanel[2].SetActive(false);
            lockedPanel[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevel5") == 1)
        {
            lockedPanel[0].SetActive(false);
            lockedPanel[1].SetActive(false);
            lockedPanel[2].SetActive(false);
            lockedPanel[3].SetActive(false);
            lockedPanel[4].SetActive(false);
        }

    }

}
