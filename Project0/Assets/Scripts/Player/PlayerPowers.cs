using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        playerData.life += PlayerPrefs.GetFloat("Health");
    }

    public void AirAttack()
    {
        enemyCreate.LoseLife(PlayerPrefs.GetInt("AirAttack"));
    }


    public void UltimatePower()
    {
        float ultimateDamage = enemyCreate.enemyLifeMax / 2;
        enemyCreate.LoseLife(ultimateDamage);
    }

}
