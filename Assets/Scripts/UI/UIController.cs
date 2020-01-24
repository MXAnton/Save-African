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
    public GameObject gameOverMenu;

    void Update()
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
        StartCoroutine(RestartLevel(1));
    }

    IEnumerator RestartLevel(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
