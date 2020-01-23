using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameMaster gameMaster;

    public TextMeshProUGUI scoreText;

    public GameObject pauseMenu;

    void Update()
    {
        scoreText.text = "" + gameMaster.score;
    }

    public void TogglePauseMenu()
    {
        if (gameMaster.gamePaused == true)
        {
            pauseMenu.SetActive(false);
            gameMaster.gamePaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            gameMaster.gamePaused = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
