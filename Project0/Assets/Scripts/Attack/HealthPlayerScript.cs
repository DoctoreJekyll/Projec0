using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPlayerScript : MonoBehaviour
{

    [SerializeField] GameObject healtTxtObj;

    public void HealthMethod()
    {
        PlayerData playerData = FindObjectOfType<PlayerData>();
        GameObject textObj = Instantiate(healtTxtObj);
        TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
        textTemp.text = PlayerPrefs.GetFloat("Health").ToString();

        playerData.life += PlayerPrefs.GetFloat("Health");
    }


}
