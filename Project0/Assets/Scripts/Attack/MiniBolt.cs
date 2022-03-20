using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBolt : MonoBehaviour
{
    EnemyCreate enemy;
    PlayerData player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyCreate>();
        player = FindObjectOfType<PlayerData>();


        enemy.LoseLife(player.atttackDamage / 2);

        Destroy(this.gameObject, 1f);

    }
}
