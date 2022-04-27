using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueT;
    [TextArea(3, 6)] public string[] dialogueText;
    public string[] buyString;

    private void Start()
    {
        StartDialogue();
    }


    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowText());
    }

    public void StartDialogueCorroutine()
    {
        StopAllCoroutines();
        StartCoroutine(ShowText());
        
    }

    public void StartBuyDialogue()
    {
        StopAllCoroutines();
        StartCoroutine(ShowCanBuyText());

    }

    public void StartCantBuyDialogue()
    {
        StopAllCoroutines();
        StartCoroutine(ShowDontBuyText());
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

    private IEnumerator ShowDontBuyText()
    {
        dialogueT.text = "";

        foreach (char ch in buyString[0])
        {
            dialogueT.text += ch;
            yield return new WaitForSeconds(0.03f);
        }

    }

    private IEnumerator ShowCanBuyText()
    {
        dialogueT.text = "";

        foreach (char ch in buyString[1])
        {
            dialogueT.text += ch;
            yield return new WaitForSeconds(0.03f);
        }

    }

}

