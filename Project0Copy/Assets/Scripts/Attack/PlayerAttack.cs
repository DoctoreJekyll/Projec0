using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    EnemyCreate enemy;
    PlayerData player;

    [SerializeField] GameObject enemyDamagedTxt;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyCreate>();
        player = FindObjectOfType<PlayerData>();

    }

    public void DoDamageEnemy()
    {
        GameObject textObj = Instantiate(enemyDamagedTxt);
        TMP_Text textTemp = textObj.GetComponent<TMP_Text>();
        textTemp.text = player.atttackDamage.ToString();
        enemy.LoseLife(player.atttackDamage);

        Destroy(gameObject, 1f);
    }
}
