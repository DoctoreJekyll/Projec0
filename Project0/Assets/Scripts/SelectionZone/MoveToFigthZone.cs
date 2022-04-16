using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveToFigthZone : MonoBehaviour
{
    public static MoveToFigthZone moveAllyInstance;

    public CheckWhoWin checkWhoWin;

    [SerializeField] private PlayerData playerData;
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

        playerData = FindObjectOfType<PlayerData>();
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
        if (Input.GetMouseButtonDown(0) && playerData.playerIsLife == true)
        {
            TouchOnSelection();
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && playerData.playerIsLife == true)
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
                StartCoroutine(MoveTo(selectionObj));
                selectionIsChoiced = true;


                EnemySelectChoice.enemySelectChoiceInstance.StartEnemyMove();
                CheckWhatOptionIsSelected(selectionObj);
                
                //checkWhoWin.CheckResultsIfTie();

            }
        }

    }

    public IEnumerator MoveTo(GameObject obj)
    {
        Vector2 tempPos = selectionObj.transform.position;
        Tween moveToTween = selectionObj.transform.DOMove(figthZone.transform.position, 0.35f);
        yield return moveToTween.WaitForCompletion();

        yield return new WaitForSeconds(0.25f);
        checkWhoWin.CheckResults();

        Tween returnMove = selectionObj.transform.DOMove(tempPos, 0.35f);
        yield return returnMove.WaitForCompletion();
        selectionIsChoiced = false;       

    }

    private void CheckWhatOptionIsSelected(GameObject selectedObj)
    {
        switch (selectedObj.name)
        {
            case "Rock":
                selections = Selections.Rock;
                break;

            case "Paper":
                selections = Selections.Paper;
                break;

            case "Scissor":
                selections = Selections.Scissor;
                break;

            default:
                break;
        }
    }

}
