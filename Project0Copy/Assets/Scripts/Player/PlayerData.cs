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
    [SerializeField] GameObject fadeIn;

    [Header("Init Values")]
    public float initLife;
    public float actualLife;
    public float initAttackDamage;
    public float initExp;


    [HideInInspector]public float maxAttackDamage;

    private void Awake()
    {

        PlayerPrefsInit();

    }

    private void PlayerPrefsInit()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Life"))
        {
            PlayerPrefs.SetFloat("Life", 100f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Damage"))
        {
            PlayerPrefs.SetFloat("Damage", 20f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Gold"))
        {
            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        maxLife = PlayerPrefs.GetFloat("Life");
        atttackDamage = PlayerPrefs.GetFloat("Damage");
        spriteRenderer = GetComponent<SpriteRenderer>();

        life = maxLife;
        playerIsLife = true;
    }

    public void LoseLife(float amount)
    {
        life -= amount;
        CameraShake.Shake(0.05f, 0.05f);
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
        GoldCap();

        if (life > maxLife)
        {
            life = maxLife;
        }

        if (life < 0)
        {
            life = 0;
        }
    }


    private void PlayerDie()//Temp
    {
        if (life <= 0)
        {
            playerIsLife = false;
            Animator playerAnimator;
            playerAnimator = GetComponent<Animator>();
            playerAnimator.SetBool("playerDead", true);
            fadeIn.SetActive(true);
        }
    }


    public void GoldBag()
    {
        gold = PlayerPrefs.GetInt("Gold");
    }


    private void GoldCap()
    {
        int cap = 999999;

        if (PlayerPrefs.GetInt("Gold") > cap)
        {
            PlayerPrefs.SetInt("Gold", cap);
            PlayerPrefs.Save();
        }
    }

}
