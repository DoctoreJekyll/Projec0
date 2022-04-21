using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUnlocked : MonoBehaviour
{
    [SerializeField] private GameObject[] lockedPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Unlocked"))
        {
            PlayerPrefs.SetInt("Unlocked", 0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //UnlockPanelByInt();
        }

        CheckUnlockedValues();

        Debug.Log("Locked" + PlayerPrefs.GetInt("Unlocked"));
    }

    public void UnlockPanelByInt(int n)
    {
        if (PlayerPrefs.GetInt("Unlocked") < lockedPanel.Length)
        {
            lockedPanel[PlayerPrefs.GetInt("Unlocked")].SetActive(false);
            int lockedNum = PlayerPrefs.GetInt("Unlocked", n);
            PlayerPrefs.SetInt("Unlocked", lockedNum);
            PlayerPrefs.Save();
        }

    }


    private void CheckUnlockedValues()
    {
        if (PlayerPrefs.GetInt("Unlocked") > 0)
        {
            lockedPanel[0].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Unlocked") > 1)
        {
            lockedPanel[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Unlocked") > 2)
        {
            lockedPanel[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Unlocked") > 3)
        {
            lockedPanel[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Unlocked") > 4)
        {
            lockedPanel[4].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Unlocked") > 5)
        {
            lockedPanel[5].SetActive(false);
        }
    }


}
