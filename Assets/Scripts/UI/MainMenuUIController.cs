using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUIController : MonoBehaviour
{
    GameObject toContainer;

    public TextMeshProUGUI latestScoreText;
    public TextMeshProUGUI highscoreText;
    //public TextMeshProUGUI[] highscoreTexts = new TextMeshProUGUI[10];

    private void Start()
    {
        UpdateShowedScores();
    }

    public void Play(GameObject fromContainer)
    {
        fromContainer.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(ChangeScene(1, 1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetToContainer(GameObject newToContainer)
    {
        toContainer = newToContainer;
    }

    public void ChangeMenuContainer(GameObject fromContainer)
    {
        fromContainer.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(DisableMenuContainer(fromContainer, 1));
    }

    IEnumerator DisableMenuContainer(GameObject whichGameObject, float time)
    {
        yield return new WaitForSeconds(time / 2);
        toContainer.SetActive(true);

        yield return new WaitForSeconds(time / 2);
        whichGameObject.SetActive(false);
    }

    IEnumerator ChangeScene(int newScene, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(newScene);
    }

    public void UpdateShowedScores()
    {
        int latestScore = PlayerPrefs.GetInt("latestScore");
        latestScoreText.text = "" + latestScore;

        int highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "" + highscore;
    }

    public void OpenWebsite()
    {
        Application.OpenURL("http://saveafricanthegame.tk/");
    }
}
