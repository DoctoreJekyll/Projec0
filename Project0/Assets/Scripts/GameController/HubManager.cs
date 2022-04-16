using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HubManager : MonoBehaviour
{

    public PlayerData playerData;

    public int goldNecesaryToUpgrade;
    public int actualGold;

    private bool canDelete;

    [Header("Hub Stuffs")]
    public TMP_Text lvlTxt;
    public TMP_Text lifeTxt;
    public TMP_Text damageTxt;
    public TMP_Text goldTxt;

    private void Update()
    {
        actualGold = PlayerPrefs.GetInt("Gold");
        Debug.Log("Life: " + PlayerPrefs.GetFloat("Life") + "Damage: " + PlayerPrefs.GetFloat("Damage") + "Gold: " + PlayerPrefs.GetInt("Gold"));


        ShowStatsOnHub();


        if (Input.GetKeyDown(KeyCode.B))
        {
            IncreasePlayerStats();
        }

        DeleteAllData();

    }

    private void ShowStatsOnHub()
    {
        lvlTxt.text = "Lvl: " + PlayerPrefs.GetInt("Level").ToString();
        lifeTxt.text = "Life: " + PlayerPrefs.GetFloat("Life").ToString();
        damageTxt.text ="Damage: " + PlayerPrefs.GetFloat("Damage").ToString();
        goldTxt.text = PlayerPrefs.GetInt("Gold").ToString() + "g";
    }

    public void IncreasePlayerStats()
    {
        if (goldNecesaryToUpgrade <= PlayerPrefs.GetInt("Gold"))
        {
            int newAmountGold = PlayerPrefs.GetInt("Gold") - goldNecesaryToUpgrade;
            PlayerPrefs.SetInt("Gold", newAmountGold);

            IncreasePlayerLife();
            IncreasePlayerDamage();
            IncreaseLevel();

            PlayerPrefs.Save();

        }
        else
        {
            Debug.Log("U cant purchase this!");
        }

    }

    public void IncreasePlayerLife()
    {
        float extraLife = 25f;
        float addLife = PlayerPrefs.GetFloat("Life") + extraLife;

        PlayerPrefs.SetFloat("Life", addLife);
    }

    public void IncreasePlayerDamage()
    {
        float extraDamage = 10f;
        float addDamage = PlayerPrefs.GetFloat("Damage") + extraDamage;

        PlayerPrefs.SetFloat("Damage", addDamage);
    }

    public void IncreaseLevel()
    {
        int extraLevel = 1;
        int newLevel = PlayerPrefs.GetInt("Level") + extraLevel;
        PlayerPrefs.SetInt("Level", newLevel);
    }

    /// <summary>
    /// ///////////////////////////////POWER UPS MÉTODOS
    /// </summary>
    /// 

    public void IncreaseHealtMagic()
    {
        if (goldNecesaryToUpgrade <= PlayerPrefs.GetInt("Gold"))
        {

            PlayerPrefs.Save();
        }
        else
        {

            Debug.Log("U cant purchase this!");
        }
    }


    public void IncreaseAirMagic()
    {
        if (goldNecesaryToUpgrade <= PlayerPrefs.GetInt("Gold"))
        {

            PlayerPrefs.Save();
        }
        else
        {

            Debug.Log("U cant purchase this!");
        }
    }
    

    public void DeleteAllData()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            canDelete = true;
            Debug.Log("Quieres borrar todos los datos? Y/N");
        }

        if (canDelete)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Has borrado todos los datos!");
                PlayerPrefs.DeleteAll();
                canDelete = false;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("No has borrado los datos");
                canDelete = false;
            }
        }
    }

}
