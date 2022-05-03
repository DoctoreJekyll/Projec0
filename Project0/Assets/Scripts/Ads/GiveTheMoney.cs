using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiveTheMoney : MonoBehaviour
{

    public static GiveTheMoney Instance;
    public int newGoldBeforeReward;
    [SerializeField] private TMP_Text rewardGoldTxt;
    [SerializeField] private TMP_Text dieRewardGoldTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        ShowTxt();
        SetNewGoldAdsRewardAmoun();
    }

    public void SetNewGoldAdsRewardAmoun()
    {
        newGoldBeforeReward = PlayerPrefs.GetInt("Gold");
    }

    public void ShowTxt()
    {
        rewardGoldTxt.text = "DO YOU WANNA SEE AD TO GET " + newGoldBeforeReward.ToString()+ " EXTRA GOLD";
        dieRewardGoldTxt.text = "DO YOU WANNA SEE AD TO GET " + newGoldBeforeReward.ToString() + " EXTRA GOLD";
    }


    public void GiveMoneyBeforeReward()
    {
        SetNewGoldAdsRewardAmoun();
        int newAmount = PlayerPrefs.GetInt("Gold") + newGoldBeforeReward;
        PlayerPrefs.SetInt("Gold", newAmount);
        PlayerPrefs.Save();

    }



}
