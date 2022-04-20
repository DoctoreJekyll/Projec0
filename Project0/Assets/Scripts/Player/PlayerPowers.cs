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
        //If USE no puedes usar de nuevo la magia durante x turnos
    }



    public void AirAttack()
    {
        Debug.Log(PlayerPrefs.GetFloat("AirAttack"));
        enemyCreate.LoseLife(PlayerPrefs.GetFloat("AirAttack"));
        ResetMagicWhenUse();
        
    }


    public void UltimatePower()
    {
        float ultimateDamage = enemyCreate.enemyLifeMax / 2;
        enemyCreate.LoseLife(ultimateDamage);
        ResetMagicWhenUse();
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
