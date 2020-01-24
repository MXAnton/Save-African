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
    public int[] localHighscores = new int[10];

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            string highscoreToGet = "highscore" + i;
            localHighscores[i] = PlayerPrefs.GetInt(highscoreToGet);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SaveScore()
    {
        if (score > localHighscores[localHighscores.Length -1])
        {
            // Replace worst highscore with new highscore and sort the highscores
            localHighscores[localHighscores.Length -1] = score;
            Array.Sort(localHighscores);
            Array.Reverse(localHighscores);

            // Save new highscorelist
            for (int i = 0; i < 10; i++)
            {
                string highscoreToSet = "highscore" + i;
                PlayerPrefs.SetInt(highscoreToSet, localHighscores[i]);
            }
            PlayerPrefs.Save();
        }
    }

    public void ResetHighscores()
    {
        for (int i = 0; i < 10; i++)
        {
            string highscoreToReset = "highscore" + i;
            PlayerPrefs.DeleteKey(highscoreToReset);
        }
    }

    public void DamagePlayer(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOn = false;
        SaveScore();
        uiController.ShowGameOverMenu();
    }
}
