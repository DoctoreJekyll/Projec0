using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDamageRecText : MonoBehaviour
{

    TMP_Text playerDamageRecibedTxt;
    EnemyCreate enemyCreate;

    private void Awake()
    {
        playerDamageRecibedTxt = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        //if (playerDamageRecibedTxt != null)
        //{
        //    enemyCreate = FindObjectOfType<EnemyCreate>();
        //    playerDamageRecibedTxt.text = enemyCreate.enemyAttack.ToString();
        //}
    }


}
