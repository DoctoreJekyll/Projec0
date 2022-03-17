using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBolt : MonoBehaviour
{

    [SerializeField] private GameObject bolt;


    public IEnumerator InstantiateBasicAttack()//TEMPORAL
    {
        yield return new WaitForSeconds(0.35f);
        Instantiate(bolt, transform.position, Quaternion.identity);
        CameraShake.Shake(0.1f, 0.15f);
    }

    public void Sorry()
    {
        StartCoroutine(InstantiateBasicAttack());
    }


}
