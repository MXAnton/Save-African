﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    GameMaster gameMaster;

    public bool inGame = false;

    void Start()
    {
        Advertisement.Initialize("3447793", false);

        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

        if (inGame == false)
        {
            StartCoroutine(LoadBanner());
        }
    }

    public void ShowNonRewardedAd()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                gameMaster.AddDiamonds(1);
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }



    IEnumerator LoadBanner()
    {
        Debug.Log("Clicked LoadBanner");
        while (!Advertisement.IsReady("banner"))
        {
            Debug.Log("Banner is not ready with state: " + Advertisement.GetPlacementState("banner"));
            yield return new WaitForSeconds(0.5f);
        }

        if (Advertisement.IsReady("banner"))
        {
            Debug.Log("Load banner");
            BannerLoadOptions bannerLoadOptions = new BannerLoadOptions();
            bannerLoadOptions.loadCallback = BannerLoadCallback;
            bannerLoadOptions.errorCallback = BannerErrorCallback;
            Advertisement.Banner.Load("banner", bannerLoadOptions);
        }
        else
        {
            Debug.Log("Banner is not ready with state: " + Advertisement.GetPlacementState("banner"));
        }
    }

    private void BannerLoadCallback()
    {
        Debug.Log("Show banner");
        Advertisement.Banner.Show();
    }

    private void BannerErrorCallback(string error)
    {
        Debug.Log("Fail to show banner with error: " + error);
    }
}