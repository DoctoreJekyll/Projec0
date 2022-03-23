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
    public float enemyAttack;
    public int enemyLevel;
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
        enemySprite = enemyData[index].enemySprite;
        spriteRenderer.sprite = enemySprite;
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

    //Llamar a m�todo que: Cuando el enemigo muera instancies cierta animaci�n, �ste m�todo adem�s de eso desactiva el sprite, el m�todo que sume el index se llamar� con una animaci�n o shader de entrar y cargar� todos los datos

    private void Update()
    {
        Die();
        LoadHud();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScriptable();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FadeToCero(0f, 0.3f));
            
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(FadeToCero(1f, 0.3f));
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

        if (index <= enemyData.Length - 1)
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
        if (index == enemyData.Length)
        {
            SceneManager.LoadScene("Hud");
        }
    }


}
