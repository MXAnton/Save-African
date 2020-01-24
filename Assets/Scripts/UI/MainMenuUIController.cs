using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUIController : MonoBehaviour
{
    public GameObject toContainer;

    public TextMeshProUGUI[] highscoreTexts = new TextMeshProUGUI[10];

    public void Play()
    {
        SceneManager.LoadScene(1);
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

    public void UpdateHighscoreList()
    {
        for (int i = 0; i < 10; i++)
        {
            string highscoreToGet = "highscore" + i;
            int highscore = PlayerPrefs.GetInt(highscoreToGet);

            highscoreTexts[i].text = i + 1 + ": " + highscore;
        }
    }
}
