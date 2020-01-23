using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public GameObject main;
    public GameObject settings;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowHighscores()
    {
        Debug.Log("Show highscores");
    }

    public void ShowSettings()
    {
        main.SetActive(false);
        settings.SetActive(true);
    }

    public void Back()
    {
        settings.SetActive(false);
        main.SetActive(true);
    }
}
