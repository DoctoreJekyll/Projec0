using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhoWin : MonoBehaviour
{

    public MoveToFigthZone allyInstance;
    public EnemySelectChoice enemyInstance;

    public bool allyWin;

    public PlayerData playerData;
    public EnemyCreate enemy;

    [Header("Attacks")]
    public InstantiateBolt instantiateTemp;
    public GameObject enemyAttack;
    public GameObject tieAttack;
    public Transform tieAttackTransform;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemy = FindObjectOfType<EnemyCreate>();
    }


    

    public void CheckResults()
    {
        switch (allyInstance.selections)
        {
            case MoveToFigthZone.Selections.Paper:
                if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.RockEnemy)
                {
                    AllyWin();
                    //enemy.LoseLife(playerData.atttackDamage);
                    instantiateTemp.Sorry();
                }
                else if(enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.PaperEnemy)
                {
                    //instantiateTemp.InstantiateMiniBolt();
                    //Instantiate(enemyTieAttack, playerData.gameObject.transform.position, Quaternion.identity);
                    //Instantiate just one obj
                    Instantiate(tieAttack, tieAttackTransform.position, Quaternion.identity);
                    Debug.Log("tie");
                }
                else if(enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.ScissorEnemy)
                {
                    //Instanciar ataque enemigo normal
                    Instantiate(enemyAttack, playerData.gameObject.transform.position, Quaternion.identity);
                    //playerData.LoseLife(enemy.enemyAttack);
                }
                break;

            case MoveToFigthZone.Selections.Scissor:
                if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.PaperEnemy)
                {
                    AllyWin();
                    //enemy.LoseLife(playerData.atttackDamage);
                    instantiateTemp.Sorry();
                }
                else if(enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.ScissorEnemy)
                {
                    Instantiate(tieAttack, tieAttackTransform.position, Quaternion.identity);
                    Debug.Log("tie");
                }
                else if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.RockEnemy)
                {
                    //Instanciar ataque enemigo normal
                    Instantiate(enemyAttack, playerData.gameObject.transform.position, Quaternion.identity);
                    //playerData.LoseLife(enemy.enemyAttack);
                }
                break;

            case MoveToFigthZone.Selections.Rock:
                if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.ScissorEnemy)
                {
                    AllyWin();
                    instantiateTemp.Sorry();
                    //enemy.LoseLife(playerData.atttackDamage);
                }
                else if(enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.RockEnemy)
                {
                    Instantiate(tieAttack, tieAttackTransform.position, Quaternion.identity);
                    Debug.Log("tie");
                }
                else if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.PaperEnemy)
                {
                    //Instanciar ataque enemigo normal
                    Instantiate(enemyAttack, playerData.gameObject.transform.position, Quaternion.identity);
                    //playerData.LoseLife(enemy.enemyAttack);
                }
                break;

            case MoveToFigthZone.Selections.None:
                break;

            default:
                break;
        }
    }

    public void AllyWin()
    {
        allyWin = true;
    }

    public void EnemyWin()
    {
        allyWin = false;
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///Comprobar el enfriamiento de las habilidades
    ///

    public void CouldownController()
    {
        MagicCouldown[] magicCouldown = FindObjectsOfType<MagicCouldown>();
        for (int i = 0; i < magicCouldown.Length; i++)
        {
            magicCouldown[i].RestMagicCould();
        }

    }

}
