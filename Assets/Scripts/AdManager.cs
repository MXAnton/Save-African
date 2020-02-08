using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    GameMaster gameMaster;

    public bool inGame = false;

    string android = "3447793";

    string reward;

    void Start()
    {
        Advertisement.Initialize(android, false);

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

    public void ShowRewardedAd(string newReward)
    {
        reward = newReward;

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
                switch (reward)
                {
                    case "diamond":
                        Debug.Log("Add diamonds");
                        gameMaster.AddDiamonds(1);
                        break;
                    case "dubbleWaterdrops":
                        Debug.Log("Dubble score");
                        gameMaster.SaveWaterdrops();
                        gameMaster.AddScore(gameMaster.score);
                        break;
                }
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
