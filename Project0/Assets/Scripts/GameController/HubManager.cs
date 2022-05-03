using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HubManager : MonoBehaviour
{

    public PlayerData playerData;
    public int actualGold;
    private bool canDelete;

    [Header("Hub Txt")]
    public TMP_Text lvlTxt;
    public TMP_Text lifeTxt;
    public TMP_Text damageTxt;
    public TMP_Text goldTxt;
    public TMP_Text goldLevelTxt;

    public TMP_Text healthLevelTxtCost;
    public TMP_Text airLevelTxtCost;

    [SerializeField] Dialogue dialogue;

    private void Awake()
    {
        dialogue = FindObjectOfType<Dialogue>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("LevelUpCost"))
        {
            PlayerPrefs.SetInt("LevelUpCost", 10);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("LevelUpHearthCost"))
        {
            PlayerPrefs.SetInt("LevelUpHearthCost", 20);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("LevelUpAirCost"))
        {
            PlayerPrefs.SetInt("LevelUpAirCost", 20);
            PlayerPrefs.Save();
        }
    }

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

        goldLevelTxt.text = PlayerPrefs.GetInt("LevelUpCost").ToString() + "g";
        healthLevelTxtCost.text = PlayerPrefs.GetInt("LevelUpHearthCost").ToString() + "g";
        airLevelTxtCost.text = PlayerPrefs.GetInt("LevelUpAirCost").ToString() + "g";
    }

    public void IncreasePlayerStats()
    {

        if (PlayerPrefs.GetInt("LevelUpCost") <= PlayerPrefs.GetInt("Gold"))
        {
            IncreasePlayerStatMethod();
            //////////Llamo aqui a los métodos del diálogo porque no se que está pasando
            ///
            dialogue.StartBuyDialogue();

        }
        else
        {
            dialogue.StartCantBuyDialogue();
            Debug.Log("U cant purchase this!");
        }

    }

    public void IncreasePlayerStatMethod()
    {
        int newAmountGold = PlayerPrefs.GetInt("Gold") - PlayerPrefs.GetInt("LevelUpCost");
        Dialogue dialogue = FindObjectOfType<Dialogue>();
        dialogue.StartBuyDialogue();////CAMBIAR LOS MÉTODOS PARA QUE SEGÚN PUEDAS COMPRAR O NO LLAMES A UN MÉTODO U OTRO QUE MUESTRE UNO U OTRO TEXTO
        PlayerPrefs.SetInt("Gold", newAmountGold);
        IncreaseLevelUpCost();

        IncreasePlayerLife();
        IncreasePlayerDamage();
        IncreaseLevel();

        PlayerPrefs.Save();
    }

    private void IncreaseLevelUpCost()
    {
        int increasePerLevel = 20;
        int newLevelUpCost = PlayerPrefs.GetInt("LevelUpCost") + increasePerLevel;
        PlayerPrefs.SetInt("LevelUpCost", newLevelUpCost);
    }

    private void IncreasePlayerLife()
    {
        float extraLife = 25f;
        float addLife = PlayerPrefs.GetFloat("Life") + extraLife;

        PlayerPrefs.SetFloat("Life", addLife);
    }

    private void IncreasePlayerDamage()
    {
        float extraDamage = 10f;
        float addDamage = PlayerPrefs.GetFloat("Damage") + extraDamage;

        PlayerPrefs.SetFloat("Damage", addDamage);
    }

    private void IncreaseLevel()
    {
        int extraLevel = 1;
        int newLevel = PlayerPrefs.GetInt("Level") + extraLevel;
        PlayerPrefs.SetInt("Level", newLevel);
    }

    /// <summary>
    /// ///////////////////////////////POWER UPS MÉTODOS///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    public void IncreaseHealtMagic()
    {
        if (PlayerPrefs.GetInt("LevelUpHearthCost") <= PlayerPrefs.GetInt("Gold"))
        {
            int newAmountGold = PlayerPrefs.GetInt("Gold") - PlayerPrefs.GetInt("LevelUpHearthCost");
            PlayerPrefs.SetInt("Gold", newAmountGold);
            float damageToAdd = 25f;
            float newAirDamage = PlayerPrefs.GetFloat("Health") + damageToAdd;
            PlayerPrefs.SetFloat("Health", newAirDamage);

            IncreaseLevelUpHealthCost();
            PlayerPrefs.Save();

            dialogue.StartBuyDialogue();

        }
        else
        {
            dialogue.StartCantBuyDialogue();
            Debug.Log("U cant purchase this!");
        }
    }

    private void IncreaseLevelUpHealthCost()
    {
        int increasePerLevel = 30;
        int newLevelUpCost = PlayerPrefs.GetInt("LevelUpHearthCost") + increasePerLevel;
        PlayerPrefs.SetInt("LevelUpHearthCost", newLevelUpCost);
    }


    public void IncreaseAirMagic()
    {
        if (PlayerPrefs.GetInt("LevelUpAirCost") <= PlayerPrefs.GetInt("Gold"))
        {
            int newAmountGold = PlayerPrefs.GetInt("Gold") - PlayerPrefs.GetInt("LevelUpAirCost");
            PlayerPrefs.SetInt("Gold", newAmountGold);
            float damageToAdd = 20f;
            float newAirDamage = PlayerPrefs.GetFloat("AirAttack") + damageToAdd;
            PlayerPrefs.SetFloat("AirAttack", newAirDamage);

            IncreaseLevelUpAirCost();

            PlayerPrefs.Save();

            dialogue.StartBuyDialogue();
        }
        else
        {
            dialogue.StartCantBuyDialogue();
            Debug.Log("U cant purchase this!");
        }
    }

    private void IncreaseLevelUpAirCost()
    {
        int increasePerLevel = 25;
        int newLevelUpCost = PlayerPrefs.GetInt("LevelUpAirCost") + increasePerLevel;
        PlayerPrefs.SetInt("LevelUpAirCost", newLevelUpCost);
    }


    /// <summary>
    /// //////////MENU MÉTODOS//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    public void QuitGame()
    {
        Application.Quit();
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

    public void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");

    }

}
