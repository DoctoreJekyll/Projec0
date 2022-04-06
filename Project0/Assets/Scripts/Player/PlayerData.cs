using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [Header("Player Data")]
    public float life;
    public float maxLife;
    public float atttackDamage;
    public int gold;
    public int playerLevel;
    private SpriteRenderer spriteRenderer;

    [Header("Other Player Stuffs")]
    public bool playerIsLife;
    [SerializeField] GameObject playerShadow;

    [Header("Init Values")]
    public float initLife;
    public float actualLife;
    public float initAttackDamage;
    public float initExp;


    [HideInInspector]public float maxAttackDamage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        life = maxLife;
        atttackDamage = 10f;
        playerIsLife = true;
    }

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
        PlayerDie();
        GoldBag();
        Debug.Log(gold);
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


    public void GoldBag()
    {
        gold = PlayerPrefs.GetInt("Gold");
    }


}
