using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemController : MonoBehaviour
{
    public ShopController shopController;

    public string item;
    public int price;
    public bool useable = true;

    public GameObject forText;
    public GameObject priceView;
    public GameObject buyConfirmationView;
    public GameObject useView;

    void Start()
    {
        UpdateItemGUI();
    }

    public void BuyItem()
    {
        if (PlayerPrefs.GetInt(item) == 0)
        {
            buyConfirmationView.SetActive(true);
        }
        else
        {
            UpdateItemGUI();
        }
    }

    public void ConfirmBuyItem()
    {
        if (PlayerPrefs.GetInt(item) == 0)
        {
            shopController.BuyClothing(item, price);
        }

        UpdateItemGUI();
    }

    public void UpdateItemGUI()
    {
        buyConfirmationView.SetActive(false);

        if (useable == true)
        {
            if (PlayerPrefs.GetInt(item) == 1)
            {
                useView.SetActive(true);
                forText.SetActive(false);
                priceView.SetActive(false);
            }
            else
            {
                useView.SetActive(false);
                forText.SetActive(true);
                priceView.SetActive(true);
            }
        }
    }

    public void ShowBuyConfirmation()
    {
        buyConfirmationView.SetActive(true);
    }

    public void UnShowBuyConfirmation()
    {
        buyConfirmationView.SetActive(false);
    }
}
