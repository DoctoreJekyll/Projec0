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

    [Header("Init Values")]
    public float initLife;
    public float initAttackDamage;
    public float initExp;

    [HideInInspector]public float maxLife;
    [HideInInspector]public float maxAttackDamage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        maxLife = 100f;
        life = maxLife;
        atttackDamage = 10f;
        initAttackDamage = 10f;
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
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
