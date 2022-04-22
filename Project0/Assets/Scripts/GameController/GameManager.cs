using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    //private static GameManager instance;

    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<GameManager>();
    //            if (instance == null)
    //            {
    //                instance = new GameObject().AddComponent<GameManager>();
    //            }
    //        }

    //        return instance;
    //    }
    //}

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(this);
    //    }

    //    DontDestroyOnLoad(this);

    //}

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [Header("Player Canvas")]
    public TMP_Text goldAmountTxt;
    public TMP_Text damageAmountTxt;
    public TMP_Text lifeAmountTxt;
    public Image barImg;

    [Header("Enemy Canvas")]
    public Image enemyImage;
    public Image enemyHealthBar;
    public TMP_Text enemyNameTxt;

    private void Update()
    {
        ShowHowMonyUHave();
        HealthPlayerBar();

        //Enemy Stuffs
        ShowEnemyFace();
        HealthEnemyBar();
        ShowEnemyName();
    }

    public void ShowHowMonyUHave()
    {
        goldAmountTxt.text = PlayerPrefs.GetInt("Gold").ToString() + "g";
        damageAmountTxt.text = PlayerPrefs.GetFloat("Damage").ToString();
        //lifeAmountTxt.text = PlayerPrefs.GetFloat("Life").ToString();
        lifeAmountTxt.text = FindObjectOfType<PlayerData>().life.ToString();
    }

    public void HealthPlayerBar()
    {
        PlayerData playerData = FindObjectOfType<PlayerData>();
        barImg.fillAmount = playerData.life / playerData.maxLife;
    }

    ////////////////////////////////////ENEMY CANVAS STUFFS//////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public void ShowEnemyFace()
    {
        EnemyCreate enemyCreate = FindObjectOfType<EnemyCreate>();
        enemyImage.sprite = enemyCreate.enemySprite;
    }

    public void HealthEnemyBar()
    {
        EnemyCreate enemyCreate = FindObjectOfType<EnemyCreate>();
        enemyHealthBar.fillAmount = enemyCreate.enemyLife / enemyCreate.enemyLifeMax;
    }

    public void ShowEnemyName()
    {
        EnemyCreate enemyCreate = FindObjectOfType<EnemyCreate>();
        enemyNameTxt.text = enemyCreate.enemyName;
    }
}
