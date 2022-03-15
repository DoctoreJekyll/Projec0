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

        enemyOptions[randomSelection].transform.DOMove(figthEnemyZone.transform.position, 0.5f);
        CheckWhatEnemySelect();
        yield return new WaitForSeconds(1f);
        enemyOptions[randomSelection].transform.DOMove(tempPos, 0.5f);

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
                Debug.Log("El enemigo a elegido la roca");
                selectionsEnemy = SelectionsEnemy.RockEnemy;
                break;

            case 1:
                Debug.Log("El enemigo a elegido la papel");
                selectionsEnemy = SelectionsEnemy.PaperEnemy;
                break;

            case 2:
                Debug.Log("El enemigo a elegido la tijera");
                selectionsEnemy = SelectionsEnemy.ScissorEnemy;
                break;

            default:
                break;
        }
    }


}
