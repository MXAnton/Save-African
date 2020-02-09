using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    Upgrades upgrades;
    public AdManager adManager;
    public UIController uiController;
    public MainMenuUIController mainMenuUIController;
    public BoostController boostController;

    public bool careerMode = true;
    public bool arcadeMode = false;

    public bool gameOn = true;
    public bool gamePaused = false;

    public int health = 3;

    public int score;
    public int latestScore;
    public int highscore;

    private void Start()
    {
        upgrades = GetComponent<Upgrades>();

        latestScore = PlayerPrefs.GetInt("latestScore");
        highscore = PlayerPrefs.GetInt("highscore");

        if (GameObject.FindWithTag("MainMenu"))
        {
            mainMenuUIController = GameObject.FindWithTag("MainMenu").GetComponent<MainMenuUIController>();
        }
    }

    public void AddScore(int amount)
    {
        if (boostController.rainingCatsAndDogs == true)
        {
            score += Mathf.CeilToInt(amount * boostController.boostAmount);
        }
        else
        {
            score += amount;
        }

        if (gameOn == true)
        {
            uiController.scoreText.text = "" + score;
        }
        uiController.gameOverScoreText.text = "" + score;

        boostController.AddCatsAndDogsAmount(amount);
    }

    public void SaveScore()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        PlayerPrefs.SetInt("latestScore", score);

        PlayerPrefs.Save();
    }

    public void AddCatchBonus()
    {
        float catchBonusDuplicator = upgrades.catchBonusStates[upgrades.currentCatchBonusState];
        score = Mathf.CeilToInt(score * catchBonusDuplicator);
    }

    public void SaveWaterdrops()
    {
        int newWaterdropsAmount = PlayerPrefs.GetInt("waterdrops");
        newWaterdropsAmount += score;

        PlayerPrefs.SetInt("waterdrops", newWaterdropsAmount);
        PlayerPrefs.Save();
    }

    public void ResetHighscores()
    {
        PlayerPrefs.DeleteKey("latestScore");
        PlayerPrefs.DeleteKey("highscore");
        //for (int i = 0; i < 10; i++)
        //{
        //    string highscoreToReset = "highscore" + i;
        //    PlayerPrefs.DeleteKey(highscoreToReset);
        //}
    }

    public void DamagePlayer(int amount)
    {
        if (boostController.rainingCatsAndDogs == false)
        {
            health -= amount;

            switch (health)
            {
                case 2:
                    uiController.RemoveLife(3);
                    break;
                case 1:
                    uiController.RemoveLife(2);
                    break;
                case 0:
                    uiController.RemoveLife(1);
                    GameOver();
                    break;
                    //default:
                    //    uiController.RemoveLife(1);
                    //    GameOver();
                    //    break;
            }
        }
    }

    void GameOver()
    {
        gameOn = false;

        if (careerMode == true)
        {
            SaveScore();
            AddCatchBonus();
            SaveWaterdrops();       
        }
        else if (arcadeMode == true)
        {
            SaveScore();
        }

        int newGameovers = PlayerPrefs.GetInt("gameovers");
        newGameovers++;
        if (newGameovers >= 2)
        {
            PlayerPrefs.SetInt("gameovers", 0);
            adManager.ShowNonRewardedAd();
        }
        else
        {
            PlayerPrefs.SetInt("gameovers", newGameovers);
        }

        PlayerPrefs.SetFloat(boostController.catsAndDogsAmountSave, boostController.catsAndDogsAmount);

        PlayerPrefs.Save();

        uiController.ShowGameOverMenu();
    }

    public void AddDiamonds(int amount)
    {
        int newDiamondsAmount = PlayerPrefs.GetInt("diamonds");
        newDiamondsAmount += amount;
        PlayerPrefs.SetInt("diamonds", newDiamondsAmount);

        PlayerPrefs.Save();

        if (mainMenuUIController != null)
        {
            mainMenuUIController.UpdateShowedCurrencies();
        }
    }
}
