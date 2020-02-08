using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeItemController : MonoBehaviour
{
    public Upgrades upgrades;
    public UpgradeController upgradeController;
    public string upgrade;
    public int[] prices;
    public int currentPrice;

    public GameObject priceView;
    public GameObject usedView;
    public GameObject buyConfirmationView;

    public GameObject upgradeBtn;
    public GameObject downgradeBtn;

    public TextMeshProUGUI upgradeLevelText;
    public bool isCatchBonus = false;

    void Start()
    {
        upgrades = GameObject.FindWithTag("GameMaster").GetComponent<Upgrades>();

        //ResetBoughtUpgrades();

        UpdateItemGUI();
    }

    public void Upgrade()
    {
        if (PlayerPrefs.GetInt(upgrade) < prices.Length - 1)
        {
            if (PlayerPrefs.GetInt(upgrade) < PlayerPrefs.GetInt("bought" + upgrade))
            {
                PlayerPrefs.SetInt(upgrade, PlayerPrefs.GetInt(upgrade) + 1);
                UpdateItemGUI();
            }
            else
            {
                buyConfirmationView.SetActive(true);
            }
        }
        else
        {
            UpdateItemGUI();
        }
    }

    public void Downgrade()
    {
        if (PlayerPrefs.GetInt(upgrade) >= 1)
        {
            PlayerPrefs.SetInt(upgrade, PlayerPrefs.GetInt(upgrade) - 1);
        }

        UpdateItemGUI();
    }

    public void ConfirmBuyUpgrade()
    {
        if (PlayerPrefs.GetInt("bought" + upgrade) < prices.Length -1)
        {
            upgradeController.BuyUpgrade(upgrade, prices);
        }

        UpdateItemGUI();
    }

    public void UpdateItemGUI()
    {
        if (PlayerPrefs.GetInt("bought" + upgrade) < prices.Length - 1)
        {
            UpdateCurrentPrice();
        }

        buyConfirmationView.SetActive(false);

        if (isCatchBonus == false)
        {
            int currentUpgradeState = PlayerPrefs.GetInt(upgrade) + 1;
            upgradeLevelText.text = "" + currentUpgradeState;
        }
        else
        {
            int currentUpgradeState = PlayerPrefs.GetInt(upgrade);
            upgradeLevelText.text = "x" + upgrades.catchBonusStates[currentUpgradeState];
        }

        if (PlayerPrefs.GetInt(upgrade) == 0)
        {
            upgradeBtn.SetActive(true);
            downgradeBtn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(upgrade) == prices.Length - 1)
        {
            upgradeBtn.SetActive(false);
            downgradeBtn.SetActive(true);
        }
        else
        {
            upgradeBtn.SetActive(true);
            downgradeBtn.SetActive(true);
        }

        if (currentPrice <= PlayerPrefs.GetInt("waterdrops") || PlayerPrefs.GetInt(upgrade) < PlayerPrefs.GetInt("bought" + upgrade))
        {
            upgradeBtn.GetComponent<Button>().enabled = true;
            upgradeBtn.GetComponent<Image>().color = Color.white;
        }
        else
        {
            upgradeBtn.GetComponent<Button>().enabled = false;
            upgradeBtn.GetComponent<Image>().color = Color.grey;
        }


        if (PlayerPrefs.GetInt(upgrade) < PlayerPrefs.GetInt("bought" + upgrade) || PlayerPrefs.GetInt("bought" + upgrade) == prices.Length - 1)
        {
            priceView.SetActive(false);
            usedView.SetActive(true);
        }
        else
        {
            usedView.SetActive(false);
            priceView.SetActive(true);
        }
    }

    public void UnShowUpgradeConfirmation()
    {
        buyConfirmationView.SetActive(false);
    }


    void UpdateCurrentPrice()
    {
        currentPrice = prices[PlayerPrefs.GetInt("bought" + upgrade)];

        priceView.GetComponentInChildren<TextMeshProUGUI>().text = "" + currentPrice;
    }


    
    void ResetBoughtUpgrades()
    {
        PlayerPrefs.SetInt(upgrade, 0);
        PlayerPrefs.SetInt("bought" + upgrade, 0);
    }
}
