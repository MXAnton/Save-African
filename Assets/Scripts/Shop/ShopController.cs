using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public MainMenuUIController mainMenuUIController;

    public GameObject notEnoughOffer;

    //int requestedBuyCost;

    public void BuyDiamonds()
    {
        if (mainMenuUIController.waterdrops >= 100)
        {
            mainMenuUIController.waterdrops -= 100;
            mainMenuUIController.diamonds += 1;

            mainMenuUIController.SaveCurrencies();
        }
        else
        {
            ShowNotEnoughOffer();
        }
    }

    public void BuyWaterdrops()
    {
        if (mainMenuUIController.diamonds >= 1)
        {
            mainMenuUIController.diamonds -= 1;
            mainMenuUIController.waterdrops += 100;

            mainMenuUIController.SaveCurrencies();
        }
        else
        {
            ShowNotEnoughOffer();
        }
    }

    public void BuyClothing(string whichClothing, int price)
    {
        if (PlayerPrefs.GetInt(whichClothing) == 0)
        {
            if (mainMenuUIController.diamonds >= price)
            {
                mainMenuUIController.diamonds -= price;

                PlayerPrefs.SetInt(whichClothing, 1);

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



    public void ChangeUsedHat(int hatID)
    {
        PlayerPrefs.SetInt("usedHat", hatID);

        PlayerPrefs.Save();
    }

    public void ChangeUsedShirt(int shirtID)
    {
        PlayerPrefs.SetInt("usedShirt", shirtID);

        PlayerPrefs.Save();
    }

    public void ChangeUsedPants(int pantsID)
    {
        PlayerPrefs.SetInt("usedPants", pantsID);

        PlayerPrefs.Save();
    }
}
