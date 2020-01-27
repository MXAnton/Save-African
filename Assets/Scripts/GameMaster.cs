using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    public UIController uiController;

    public bool gameOn = true;
    public bool gamePaused = false;

    public int health = 3;

    public int score;
    public int latestScore;
    public int highscore;

    private void Start()
    {
        latestScore = PlayerPrefs.GetInt("latestScore");
        highscore = PlayerPrefs.GetInt("highscore");
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SaveScore()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        PlayerPrefs.SetInt("latestScore", score);

        PlayerPrefs.Save();

        //if (score > localHighscores[localHighscores.Length -1])
        //{
        //    // Replace worst highscore with new highscore and sort the highscores
        //    localHighscores[localHighscores.Length -1] = score;
        //    Array.Sort(localHighscores);
        //    Array.Reverse(localHighscores);

        //    // Save new highscorelist
        //    for (int i = 0; i < 10; i++)
        //    {
        //        string highscoreToSet = "highscore" + i;
        //        PlayerPrefs.SetInt(highscoreToSet, localHighscores[i]);
        //    }
        //    PlayerPrefs.Save();
        //}
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

    void GameOver()
    {
        gameOn = false;
        SaveScore();
        uiController.ShowGameOverMenu();
    }
}
