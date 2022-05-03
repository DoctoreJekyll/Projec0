using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxAnimFaded : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(JustInLogoChusta());
    }


    IEnumerator JustInLogoChusta()
    {
        Animator animator = GetComponent<Animator>();
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("FadeInn");

    }


}
