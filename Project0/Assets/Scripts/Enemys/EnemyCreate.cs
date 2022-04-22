using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCreate : MonoBehaviour
{
    public EnemyData[] enemyData;
    private int index;

    [Header("Enemy Info")]
    public string enemyName;
    public float enemyLife;
    public float enemyLifeMax;
    public float enemyAttack;
    public int enemyLevel;
    public int goldDropped;
    public Sprite enemySprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        enemyName = enemyData[index].name;
        enemyLife = enemyData[index].enemyLife;
        enemyAttack = enemyData[index].enemyAttack;
        enemyLevel = enemyData[index].enemyLevel;
        goldDropped = enemyData[index].gold;
        enemySprite = enemyData[index].enemySprite;
        spriteRenderer.sprite = enemySprite;

        enemyLifeMax = enemyLife;
    }

    public void HitPlayer(float amount)
    {
        enemyAttack = amount;
    }

    public void LoseLife(float amount)
    {
        enemyLife -= amount;
        if (enemyLife > 0)
        {
            StartCoroutine(LoseLifeAnimTemp());
        }
        else if (enemyLife <= 0)
        {
            StopAllCoroutines();
        }

    }

    //Llamar a método que: Cuando el enemigo muera instancies cierta animación, éste método además de eso desactiva el sprite, el método que sume el index se llamará con una animación o shader de entrar y cargará todos los datos

    private void Update()
    {
        Debug.Log(enemyData.Length);
        Debug.Log(index);

        Die();
        LoadHud();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScriptable();
        }

    }

    public void Die()
    {

        if (enemyLife <= 0)
        {
            StartCoroutine(FadeToCero(0f, 0.5f));

        }
    }

    private IEnumerator LoseLifeAnimTemp()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }

    public void LoadScriptableData()
    {
        enemyName = enemyData[index].name;
        enemyLife = enemyData[index].enemyLife;
        enemyAttack = enemyData[index].enemyAttack;
        enemyLevel = enemyData[index].enemyLevel;
        enemySprite = enemyData[index].enemySprite;
        spriteRenderer.sprite = enemySprite;

        enemyLifeMax = enemyLife;

        StopAllCoroutines();
    }

    private void LoadNextScriptable()
    {
        index++;
        LoadScriptableData();
    }


    IEnumerator FadeToCero(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }

        GiveGoldToPlayer();

        if (index < enemyData.Length)
        {
            LoadNextScriptable();
        }

        StartCoroutine(FadeToOne(1, 0.3f));

    }

    IEnumerator FadeToOne(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }

    }


    private void LoadHud()
    {
        UnlockerByLevel unlockerByLevel = FindObjectOfType<UnlockerByLevel>();


        if (index == enemyData.Length)
        {
            unlockerByLevel.CheckSceneNameAndSetUnlockPref();
            SceneManager.LoadScene("Hub");
        }
    }


    //Todo... LA IDEA ES QUE CUANDO TERMINES UNA ESCENA, EL LOCKED DE LA SIGUIENTE SE DESBLOQUEE Y SE QUEDE DESBLOQUEADO
    //CADA ESCENA DESBLOQUEA 1 Y SOLO 1, ESTO ES UN PROBLEMA, BUENA SUERTE JOSE DEL FUTURO.

    /////////////////////////////////////////////////////////////////////GOLD STUFF/////////////////////////////////////////////////////////////////


    public void GoldDrop()
    {
        PlayerPrefs.SetInt("Gold", goldDropped);
        PlayerPrefs.Save();
    }

    public void GiveGoldToPlayer()
    {
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.gold += goldDropped;
        PlayerPrefs.SetInt("Gold", playerData.gold);
        PlayerPrefs.Save();     

    }
}
