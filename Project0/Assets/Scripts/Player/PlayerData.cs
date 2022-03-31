using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [Header("Player Data")]
    public float life;
    public float atttackDamage;
    public float gold;
    public int playerLevel;
    private SpriteRenderer spriteRenderer;

    [Header("Other Player Stuffs")]
    public bool playerIsLife;
    [SerializeField] GameObject playerShadow;

    [Header("Init Values")]
    public float initLife;
    public float initAttackDamage;
    public float initExp;

    public float maxLife;
    [HideInInspector]public float maxAttackDamage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //maxLife = 200f;
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
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }

    private void Update()
    {
        PlayerStats();
        
        PlayerDie();

    }

    public void PlayerStats()
    {
        gold = GameManager.Instance.gameGold;
        life = GameManager.Instance.playerLifeManager;
        atttackDamage = GameManager.Instance.playerAttackManager;
        playerLevel = GameManager.Instance.playerLevel;
    }

    private void PlayerDie()//Temp
    {
        if (life <= 0)
        {
            playerIsLife = false;
            spriteRenderer.enabled = false;
            playerShadow.SetActive(false);
            SceneManager.LoadScene("Hub");
        }
    }


}
