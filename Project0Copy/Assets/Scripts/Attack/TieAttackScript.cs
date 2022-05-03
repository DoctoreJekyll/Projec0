using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TieAttackScript : MonoBehaviour
{

    [SerializeField] PlayerData playerData;
    [SerializeField] EnemyCreate enemyCreate;

    [SerializeField] GameObject playerTextDamaged;
    [SerializeField] GameObject enemyTextDamaged;

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


        GameObject tempObj = Instantiate(enemyTextDamaged);
        TMP_Text textTemp2 = tempObj.GetComponent<TMP_Text>();
        textTemp2.text = damageEnemyRecibed.ToString();
        enemyCreate.LoseLife(damageEnemyRecibed);

        if (damagePlayerRecibed >= playerData.life)
        {
            playerData.life = 1f;
        }
        else
        {
            GameObject textObj = Instantiate(playerTextDamaged);
            TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
            textTemp.text = damagePlayerRecibed.ToString();
            playerData.LoseLife(damagePlayerRecibed);
        }

    }


}
