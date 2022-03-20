using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Llamar a método que: Cuando el enemigo muera instancies cierta animación, éste método además de eso desactiva el sprite, el método que sume el index se llamará con una animación o shader de entrar y cargará todos los datos

    private void Update()
    {
        Die();

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
        LoadNextScriptable();
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


}
