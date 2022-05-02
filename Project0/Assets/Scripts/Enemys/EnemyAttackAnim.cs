using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAttackAnim : MonoBehaviour
{

    PlayerData playerData;
    EnemyCreate enemyCreate;

    [SerializeField] GameObject playerTextDamaged;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemyCreate = FindObjectOfType<EnemyCreate>();
    }

    public void DoDamageToPlayer()
    {
        playerData.LoseLife(enemyCreate.enemyAttack);

        GameObject textObj = Instantiate(playerTextDamaged);
        TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
        textTemp.text = enemyCreate.enemyAttack.ToString();
        Destroy(this.gameObject, 1f);
    }

    public void DoDamageToPlayerIfTie()
    {
        playerData.LoseLife(enemyCreate.enemyAttack / 2);
        float t = enemyCreate.enemyAttack / 2;

        GameObject textObj = Instantiate(playerTextDamaged);
        TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
        textTemp.text = t.ToString();
        Destroy(textObj, 1f);
        Destroy(this.gameObject, 1f);
    }


}
