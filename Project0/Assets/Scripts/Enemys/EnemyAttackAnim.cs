using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnim : MonoBehaviour
{

    PlayerData playerData;
    EnemyCreate enemyCreate;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemyCreate = FindObjectOfType<EnemyCreate>();
    }

    public void DoDamageToPlayer()
    {
        playerData.LoseLife(enemyCreate.enemyAttack);
        Destroy(this.gameObject, 1f);
    }

    public void DoDamageToPlayerIfTie()
    {
        playerData.LoseLife(enemyCreate.enemyAttack / 2);
        Destroy(this.gameObject, 1f);
    }


}
