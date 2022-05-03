using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSelections : MonoBehaviour
{

    public EnemySelectChoice enemySelectChoice;
    public MoveToFigthZone moveToFigthZone;

    [SerializeField] private GameObject allySelection;
    [SerializeField] private GameObject enemySelection;


    public void ReturnSelectionsValue()
    {
        moveToFigthZone.selections = MoveToFigthZone.Selections.None;
        enemySelectChoice.selectionsEnemy = EnemySelectChoice.SelectionsEnemy.None;
    }


}
