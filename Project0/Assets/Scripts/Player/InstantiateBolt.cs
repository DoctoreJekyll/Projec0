using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBolt : MonoBehaviour
{

    [SerializeField] private GameObject bolt;
    [SerializeField] private GameObject miniBolt;


    public void InstantiateBasicAttack()//TEMPORAL
    {
        //yield return new WaitForSeconds(0.35f);
        Instantiate(bolt, transform.position, Quaternion.identity);
        CameraShake.Shake(0.1f, 0.18f);
    }

    public void Sorry()
    {
        InstantiateBasicAttack();
    }


    public void InstantiateMiniBolt()
    {
        Instantiate(miniBolt, transform.position, Quaternion.identity);
        CameraShake.Shake(0.1f, 0.1f);
    }


}
