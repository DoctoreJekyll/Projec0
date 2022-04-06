using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour
{

    public PlayerData playerData;

    public int goldNecesaryToUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log("Life: " + playerData.maxLife + "Damage: " + playerData.atttackDamage);
    }

    public void IncreasePlayerStats(int lifeIncrement, int attackIncrement, int necesaryGold)
    {
        if (necesaryGold <= playerData.gold)
        {
            playerData.gold = playerData.gold - necesaryGold;
            PlayerPrefs.SetFloat("Gold", playerData.gold);

            playerData.maxLife += lifeIncrement;
            playerData.atttackDamage += attackIncrement;

            PlayerPrefs.SetFloat("PlayerLife", playerData.maxLife);
            PlayerPrefs.SetFloat("PlayerAttack", playerData.atttackDamage);
            PlayerPrefs.Save();

        }
        else
        {
            Debug.Log("U cant purchase this!");
        }

    }



}
