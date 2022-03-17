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

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        enemy = FindObjectOfType<EnemyCreate>();
    }

    public InstantiateBolt instantiateTemp;

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
                    Debug.Log("El enemigo ha elegido piedra y tu papel, por tanto tú ganas");
                }
                else if((allyInstance.selections == MoveToFigthZone.Selections.Paper) && (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.PaperEnemy))
                {
                    instantiateTemp.Sorry();
                }
                else
                {
                    playerData.LoseLife(enemy.enemyAttack);
                }
                break;
            case MoveToFigthZone.Selections.Scissor:
                if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.PaperEnemy)
                {
                    AllyWin();
                    //enemy.LoseLife(playerData.atttackDamage);
                    instantiateTemp.Sorry();
                    Debug.Log("El enemigo ha elegido papel y tu tijeras, por tanto tú ganas");
                }
                else if((allyInstance.selections == MoveToFigthZone.Selections.Scissor) && (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.ScissorEnemy))
                {
                    instantiateTemp.Sorry();
                }
                else
                {
                    playerData.LoseLife(enemy.enemyAttack);
                }
                break;
            case MoveToFigthZone.Selections.Rock:
                if (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.ScissorEnemy)
                {
                    AllyWin();
                    instantiateTemp.Sorry();
                    //enemy.LoseLife(playerData.atttackDamage);
                    Debug.Log("El enemigo ha elegido tijeras y tu rocas, por tanto tú ganas");
                }
                else if((allyInstance.selections == MoveToFigthZone.Selections.Rock) && (enemyInstance.selectionsEnemy == EnemySelectChoice.SelectionsEnemy.RockEnemy))
                {
                    instantiateTemp.Sorry();
                }
                else
                {
                    playerData.LoseLife(enemy.enemyAttack);
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

}
