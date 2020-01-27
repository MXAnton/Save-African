using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public MainMenuUIController mainMenuUIController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowBuyConfirmation(GameObject buyConfirmation)
    {
        buyConfirmation.SetActive(true);
    }

    public void BuyDiamonds()
    {
        if (mainMenuUIController.waterdrops >= 100)
        {
            mainMenuUIController.waterdrops -= 100;
            mainMenuUIController.diamonds += 1;

            mainMenuUIController.SaveCurrencies();
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
    }
}
