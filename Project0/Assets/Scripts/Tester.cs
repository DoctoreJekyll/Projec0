using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    EnemyCreate enemy;
    PlayerData player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyCreate>();
        player = FindObjectOfType<PlayerData>();


        enemy.LoseLife(player.atttackDamage);

        Destroy(this.gameObject, 1f);

    }
}
