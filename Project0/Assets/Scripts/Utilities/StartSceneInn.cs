using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneInn : MonoBehaviour
{

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Hub");
    }


}
