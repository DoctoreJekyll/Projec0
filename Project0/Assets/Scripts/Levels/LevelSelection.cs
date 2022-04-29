using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public Animator animator;

    public void JoseDelFuturoPerdonPorEsto()
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeInn");
        }
    }

}
