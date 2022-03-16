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
        LoadScriptableData();
    }

    public void HitPlayer(float amount)
    {
        enemyAttack = amount;
    }

    public void LoseLife(float amount)
    {
        enemyLife -= amount;
        StartCoroutine(LoseLifeAnimTemp());
        Debug.Log("El enemigo Ha perdido vida");
    }



    private void Update()
    {
        Debug.Log(enemyLife);

        if (enemyLife <= 0) LoadNextScriptable();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScriptable();
        }

    }

    private IEnumerator LoseLifeAnimTemp()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.35f);
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
    }

    private void LoadNextScriptable()
    {
        index++;
        LoadScriptableData();
    }

}
