using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveToFigthZone : MonoBehaviour
{
    public static MoveToFigthZone moveAllyInstance;

    private void Awake()
    {
        if (moveAllyInstance == null)
        {
            moveAllyInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    [SerializeField] private GameObject selectionObj;
    [SerializeField] private GameObject figthZone;
    [SerializeField] private bool selectionIsChoiced;

    [Header("Selection")]
    public int selects;
    public enum Selections
    {
        Paper,
        Scissor,
        Rock,
        None
    }

    public Selections selections;

    // Start is called before the first frame update
    void Start()
    {
        selections = Selections.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchOnSelection();
        }
        
    }

    private void TouchOnSelection()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("AllySelect") && selectionIsChoiced == false)
            {
                selectionObj = hit.collider.gameObject;
                MoveTo(selectionObj);
                selectionIsChoiced = true;


                EnemySelectChoice.enemySelectChoiceInstance.MoveSelectionEnemy();
                CheckWhatOptionIsSelected(selectionObj);

            }
        }

    }

    private Tween MoveTo(GameObject obj)
    {
        Tween moveToTween = selectionObj.transform.DOMove(figthZone.transform.position, 1f);
        return moveToTween;
    }

    private void CheckWhatOptionIsSelected(GameObject selectedObj)
    {
        switch (selectedObj.name)
        {
            case "Rock":
                Debug.Log("El player ha seleccionado la roca");
                selections = Selections.Rock;
                break;

            case "Paper":
                Debug.Log("El player ha seleccionado el papel");
                selections = Selections.Paper;
                break;

            case "Scissor":
                Debug.Log("El player ha seleccionado la tijera");
                selections = Selections.Scissor;
                break;

            default:
                break;
        }
    }

}
