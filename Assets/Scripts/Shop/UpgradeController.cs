using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public MainMenuUIController mainMenuUIController;

    public GameObject notEnoughOffer;

    public UpgradeItemController[] itemControllers;

    public void BuyUpgrade(string whichUpgrade, int[] prices)
    {
        int currentUpgradeState = PlayerPrefs.GetInt(whichUpgrade);

        if (currentUpgradeState < prices.Length - 1)
        {
            if (mainMenuUIController.waterdrops >= prices[currentUpgradeState])
            {
                mainMenuUIController.waterdrops -= prices[currentUpgradeState];

                PlayerPrefs.SetInt(whichUpgrade, PlayerPrefs.GetInt(whichUpgrade) + 1);
                PlayerPrefs.SetInt("bought" + whichUpgrade, PlayerPrefs.GetInt("bought" + whichUpgrade) + 1);

                mainMenuUIController.SaveCurrencies();
            }
            else
            {
                ShowNotEnoughOffer();
            }
        }
        else
        {
            Debug.Log("Already bought");
        }
    }

    public void ShowNotEnoughOffer()
    {
        notEnoughOffer.SetActive(true);
    }

    public void UpdateAllUpgrades()
    {
        foreach (UpgradeItemController itemController in itemControllers)
        {
            itemController.UpdateItemGUI();
        }
    }
}
