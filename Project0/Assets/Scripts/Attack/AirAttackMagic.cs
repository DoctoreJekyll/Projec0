using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttackMagic : MonoBehaviour
{

    public void AirAttackDamage()
    {
        PlayerPowers playerPowers = FindObjectOfType<PlayerPowers>();
        playerPowers.AirAttack();
        CameraShake.Shake(0.1f, 0.18f);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

}
