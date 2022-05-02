using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPowers : MonoBehaviour
{

    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemyCreate enemyCreate;
    [SerializeField] GameObject enemyDamagedTxt;

    [Header("Power Variables")]
    public float healthAmount;
    public float airAttackDamage;
    public float ultimateDamage;

    [Header("Magic Instantiate")]
    public GameObject healthMagic;
    public GameObject airMagic;
    public GameObject ultimateMagic;
    public Transform ultimatePosition;
    

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemyCreate = FindObjectOfType<EnemyCreate>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetFloat("Health", 10);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("AirAttack"))
        {
            PlayerPrefs.SetFloat("AirAttack", 5f);
            PlayerPrefs.Save();
        }

    }


    public void HealthPower()
    {
        playerData.life += PlayerPrefs.GetFloat("Health");

        Vector3 t = new Vector3(0f, -0.22f, 0f);//Posicion debajo del jugador
        Instantiate(healthMagic, t, Quaternion.identity);
    }


    public void InstantiateAirAttack()
    {
        Instantiate(airMagic, enemyCreate.transform.position, Quaternion.identity);
    }

    public void AirAttack()
    {
        GameObject textObj = Instantiate(enemyDamagedTxt);
        TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
        textTemp.text = PlayerPrefs.GetFloat("AirAttack").ToString();
        enemyCreate.LoseLife(PlayerPrefs.GetFloat("AirAttack"));
        Destroy(textObj, 1f);
        //ResetMagicWhenUse();
        
    }


    public void UltimatePower()
    {
        float ultimateDamage = enemyCreate.enemyLifeMax / 2;
        GameObject textObj = Instantiate(enemyDamagedTxt);
        TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
        textTemp.text = ultimateDamage.ToString();
        enemyCreate.LoseLife(ultimateDamage);
        //ResetMagicWhenUse();
    }

    public void InstantiateUltimateAttack()
    {
        Instantiate(ultimateMagic, ultimatePosition.position, Quaternion.identity);
    }


    private void ResetMagicWhenUse()
    {
        MagicCouldown[] magicCouldown = FindObjectsOfType<MagicCouldown>();
        for (int i = 0; i < magicCouldown.Length; i++)
        {
            magicCouldown[i].ResetCould();
        }
    }

}
