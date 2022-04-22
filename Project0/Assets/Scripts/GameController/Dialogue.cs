using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueT;

    private int dialogueIndex;
    [TextArea(3, 6)] public string[] dialogueText;
    public string[] buyString;

    private bool didDialogueStart;

    private void Start()
    {
        StartDialogue();
    }


    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);

        StartCoroutine(ShowText());
    }

    //private void NextDialogueLine()
    //{
    //    dialogueIndex++;
    //    if (dialogueIndex < dialogueText.Length)
    //    {
    //        StartCoroutine(ShowText());
    //    }
    //    else
    //    {
    //        CloseText();
    //    }

    //}

    private void CloseText()
    {
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
    }

    public void StartDialogueCorroutine()
    {
        StopAllCoroutines();
        StartCoroutine(ShowText());
        
    }

    public void StartBuyDialogue()
    {
        StopAllCoroutines();
        StartCoroutine(ShowBuyText());
    }

    private IEnumerator ShowText()
    {
        int randomTemp = Random.Range(0, dialogueText.Length);

        dialogueT.text = "";
        foreach (char ch in dialogueText[randomTemp])
        {
            dialogueT.text += ch;
            yield return new WaitForSeconds(0.03f);
        }
    }

    private IEnumerator ShowBuyText()
    {
        dialogueT.text = "";

        if (PlayerPrefs.GetInt("LevelUpCost") > PlayerPrefs.GetInt("Gold"))
        {
            foreach (char ch in buyString[0])
            {
                dialogueT.text += ch;
                yield return new WaitForSeconds(0.03f);
            }
        }

        if (PlayerPrefs.GetInt("LevelUpCost") < PlayerPrefs.GetInt("Gold"))
        {
            foreach (char ch in buyString[1])
            {
                dialogueT.text += ch;
                yield return new WaitForSeconds(0.03f);
            }
        }


    }

}

