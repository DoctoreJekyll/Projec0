using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateMagic : MonoBehaviour
{

    public void UltimateDamage()
    {
        PlayerPowers playerPowers = FindObjectOfType<PlayerPowers>();
        playerPowers.UltimatePower();
        CameraShake.Shake(0.2f, 0.2f);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

    }



}
