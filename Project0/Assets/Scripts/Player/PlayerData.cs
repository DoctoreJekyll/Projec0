using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Player Data")]
    public float life;
    public float atttackDamage;
    public float totalExp;
    public int playerLevel;
    private SpriteRenderer spriteRenderer;
    public bool playerIsLife;
    [SerializeField] GameObject playerShadow;

    [Header("Init Values")]
    public float initLife;
    public float initAttackDamage;
    public float initExp;

    [HideInInspector]public float maxLife;
    [HideInInspector]public float maxAttackDamage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        maxLife = 200f;
        life = maxLife;
        atttackDamage = 10f;
        initAttackDamage = 10f;
        playerIsLife = true;
    }

    //public void HitEnemy(float amount)
    //{
    //    EnemyCreate enemyCreate = FindObjectOfType<EnemyCreate>();
    //    enemyCreate.LoseLife(atttackDamage);
    //}

    public void LoseLife(float amount)
    {
        life -= amount;
        StartCoroutine(LoseLifeAnimTemp());
    }

    private IEnumerator LoseLifeAnimTemp()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.35f);
        spriteRenderer.color = Color.white;
    }

    private void Update()
    {
        PlayerDie();
    }

    private void PlayerDie()//Temp
    {
        if (life <= 0)
        {
            playerIsLife = false;
            spriteRenderer.enabled = false;
            playerShadow.SetActive(false);
        }
    }


}
