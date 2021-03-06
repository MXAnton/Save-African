﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameMaster gameMaster;
    [Space]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;

    public Slider catsSlider;
    public Slider dogsSlider;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public GameObject[] lifes;


    void Start()
    {
        scoreText.text = "" + gameMaster.score;
    }

    public void TogglePauseMenu()
    {
        if (gameMaster.gamePaused == false && gameMaster.gameOn == true)
        {
            pauseMenu.SetActive(true);
            gameMaster.gamePaused = true;
        }
        else
        {
            StartCoroutine(DisableMenuContainer(pauseMenu, 1));
        }
    }

    IEnumerator DisableMenuContainer(GameObject whichGameObject, float time)
    {
        whichGameObject.GetComponent<Animator>().SetTrigger("Out");

        yield return new WaitForSeconds(time);
        whichGameObject.SetActive(false);
        gameMaster.gamePaused = false;
    }

    public void OnRestartLevel(GameObject fromMenu)
    {
        fromMenu.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex, 1));
    }

    public void MainMenu(GameObject fromMenu)
    {
        fromMenu.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(ChangeScene(0, 1));
    }

    IEnumerator ChangeScene(int newScene, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(newScene);
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = "" + gameMaster.score;
    }

    public void RemoveLife(int whichLife)
    {
        lifes[whichLife - 1].SetActive(false);
    }

    public void UpdateCatsAndDogsSliders(float newValue)
    {
        if (newValue > 1)
        {
            newValue = 1;
        }
        else if (newValue < 0)
        {
            newValue = 0;
        }

        catsSlider.value = newValue / 2;
        dogsSlider.value = newValue / 2;
    }
}
