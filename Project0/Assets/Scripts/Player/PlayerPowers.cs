using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{

    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemyCreate enemyCreate;

    // Start is called before the first frame update
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemyCreate = FindObjectOfType<EnemyCreate>();
    }


    public void HealthPower()
    {
        float healtAmount = 25f;
        playerData.life += healtAmount;

    }

    public void AirAttack(float attackDamage)
    {
        enemyCreate.LoseLife(attackDamage);
    }

    public void UltimatePower()
    {
        float ultimateDamage = enemyCreate.enemyLifeMax / 2;
        enemyCreate.LoseLife(ultimateDamage);
    }

}
