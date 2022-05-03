using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="Enemy")]
public class EnemyData : ScriptableObject
{

    public string enemyName;
    public int enemyLevel;
    public float enemyAttack;
    public float enemyLife;
    public int gold;


    public Sprite enemySprite;



}

