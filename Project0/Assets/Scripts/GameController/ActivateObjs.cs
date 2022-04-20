using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjs : MonoBehaviour
{

    public void ActivateDesactivateObj(GameObject objToDesactivate)
    {
        if (!objToDesactivate.activeSelf)
        {
            objToDesactivate.SetActive(true);
        }
        else if (objToDesactivate.activeSelf == true)
        {
            objToDesactivate.SetActive(false);
        }
    }



}
