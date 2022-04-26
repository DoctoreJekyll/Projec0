using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPowers : MonoBehaviour
{

    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemyCreate enemyCreate;

    [Header("Power Variables")]
    public float healthAmount;
    public float airAttackDamage;
    public float ultimateDamage;

    [Header("Magic Instantiate")]
    public GameObject healthMagic;
    public GameObject airMagic;
    public GameObject ultimateMagic;
    

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
        Debug.Log(PlayerPrefs.GetFloat("Health"));
        playerData.life += PlayerPrefs.GetFloat("Health");

        Vector3 t = new Vector3(0f, -0.22f, 0f);//Posicion debajo del jugador
        Instantiate(healthMagic, t, Quaternion.identity);
    }



    public void AirAttack()
    {
        Debug.Log(PlayerPrefs.GetFloat("AirAttack"));
        enemyCreate.LoseLife(PlayerPrefs.GetFloat("AirAttack"));
        //ResetMagicWhenUse();
        
    }


    public void UltimatePower()
    {
        float ultimateDamage = enemyCreate.enemyLifeMax / 2;
        enemyCreate.LoseLife(ultimateDamage);
        //ResetMagicWhenUse();
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
