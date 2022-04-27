using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieAttackScript : MonoBehaviour
{

    [SerializeField] PlayerData playerData;
    [SerializeField] EnemyCreate enemyCreate;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemyCreate = FindObjectOfType<EnemyCreate>();
    }

    private void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);//Espera a que acabe la animacion para destruir
    }

    public void Tie()
    {
        float damageEnemyRecibed = playerData.atttackDamage / 2;
        float damagePlayerRecibed = (enemyCreate.enemyAttack / 2) / 2;

        enemyCreate.LoseLife(damageEnemyRecibed);

        if (damagePlayerRecibed >= playerData.life)
        {
            playerData.life = 1f;
        }
        else
        {
            playerData.LoseLife(damagePlayerRecibed);
        }

    }


}
