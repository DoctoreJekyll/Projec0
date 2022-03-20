using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySelectChoice : MonoBehaviour
{

    public static EnemySelectChoice enemySelectChoiceInstance;

    public GameObject[] enemyOptions;
    [SerializeField] private GameObject figthEnemyZone;

    private int randomSelection;

    public enum SelectionsEnemy
    {
        PaperEnemy,
        ScissorEnemy,
        RockEnemy,
        None
    }

    public SelectionsEnemy selectionsEnemy;

    private void Awake()
    {
        if (enemySelectChoiceInstance == null)
        {
            enemySelectChoiceInstance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    void Start()
    {
        selectionsEnemy = SelectionsEnemy.None;
    }


    public IEnumerator MoveSelectionEnemy()
    {
        randomSelection = Random.Range(0, enemyOptions.Length);
        Vector2 tempPos;
        tempPos = enemyOptions[randomSelection].transform.position;


        Tween enemyTween = enemyOptions[randomSelection].transform.DOMove(figthEnemyZone.transform.position, 0.35f);
        yield return enemyTween.WaitForCompletion();
        CheckWhatEnemySelect();
        yield return new WaitForSeconds(0.25f);
        enemyOptions[randomSelection].transform.DOMove(tempPos, 0.35f);

    }

    public void StartEnemyMove()
    {
        StartCoroutine(MoveSelectionEnemy());
    }

    public void CheckWhatEnemySelect()
    {
        switch (randomSelection)
        {
            case 0:
                selectionsEnemy = SelectionsEnemy.RockEnemy;
                break;

            case 1:
                selectionsEnemy = SelectionsEnemy.PaperEnemy;
                break;

            case 2:
                selectionsEnemy = SelectionsEnemy.ScissorEnemy;
                break;

            default:
                break;
        }
    }


}
