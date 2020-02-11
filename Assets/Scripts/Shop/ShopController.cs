using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public ShopItems shopItems;
    public MainMenuUIController mainMenuUIController;

    public RectTransform itemsHolder;
    public GameObject notEnoughOffer;

    private void Start()
    {
        mainMenuUIController.SaveCurrencies();

        UpdateItemsHolderWidth();
    }

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

    public void ChangeUsedHead(int headID)
    {
        PlayerPrefs.SetInt("usedHead", headID);

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



    public void ChangeShowedItems(TMP_Dropdown dropdown)
    {
        int newShowedItems = dropdown.value;

        switch (newShowedItems)
        {
            case 1:
                SetShowedItems(true, false, false, false);
                break;
            case 2:
                SetShowedItems(false, true, false, false);
                break;
            case 3:
                SetShowedItems(false, false, true, false);
                break;
            case 4:
                SetShowedItems(false, false, false, true);
                break;
            default:
                SetShowedItems(true, true, true, true);
                break;
        }
    }

    void SetShowedItems(bool hatItems, bool headItems, bool shirtItems, bool pantsItems)
    {
        foreach (GameObject hatItem in shopItems.hatItems)
        {
            hatItem.SetActive(hatItems);
        }
        foreach (GameObject headItem in shopItems.headItems)
        {
            headItem.SetActive(headItems);
        }
        foreach (GameObject shirtItem in shopItems.shirtItems)
        {
            shirtItem.SetActive(shirtItems);
        }
        foreach (GameObject pantsItem in shopItems.pantsItems)
        {
            pantsItem.SetActive(pantsItems);
        }

        UpdateItemsHolderWidth();
    }

    void UpdateItemsHolderWidth()
    {
        int activeChildren = 0;
        foreach (Transform child in itemsHolder.transform)
        {
            if (child.gameObject.activeSelf)
            {
                activeChildren++;
            }
        }

        itemsHolder.sizeDelta = new Vector2(activeChildren * 360 + 20, itemsHolder.sizeDelta.y);
    }
}
