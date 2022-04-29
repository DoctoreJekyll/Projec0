using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDmgTxt : MonoBehaviour
{

    EnemyCreate enemyCreate;
    [SerializeField] private TMP_Text txtDamagePlayer;

    private void Awake()
    {
        enemyCreate = FindObjectOfType<EnemyCreate>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InstantiateTxtObj();
        }
    }


    public void InstantiateTxtObj()
    {
        Instantiate(txtDamagePlayer);
    }



}
