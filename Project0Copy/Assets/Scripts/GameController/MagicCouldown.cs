using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCouldown : MonoBehaviour
{
    [Header("Uses")]
    [SerializeField] private float magicCouldown;
    [SerializeField] private float magicCouldownMax;

    [Header("Canvas Stuffs")]
    [SerializeField] private Image couldDownImg;


    // Start is called before the first frame update
    void Start()
    {
        magicCouldown = magicCouldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthCouldown();
    }

    public void RestMagicCould()
    {
        magicCouldown -= 1;
    }

    public void ResetCould()
    {
        magicCouldown = magicCouldownMax;
        couldDownImg.enabled = true;
    }


    private void SetHealthCouldown()
    {
        couldDownImg.fillAmount = magicCouldown / magicCouldownMax;
        if (couldDownImg.fillAmount == 0)
        {
            couldDownImg.enabled = false;
        }
    }

}
