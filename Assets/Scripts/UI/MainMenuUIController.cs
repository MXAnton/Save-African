﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public SoundsController soundsController;

    GameObject toContainer;

    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI highscoreText;
    //public TextMeshProUGUI[] highscoreTexts = new TextMeshProUGUI[10];

    public Slider soundEffectsVolumeSlider;
    public Slider musicVolumeSlider;
    public Sprite[] sliderHandleSprites;

    [Header("Money Vars")]
    public int waterdrops;
    public int diamonds;

    public TextMeshProUGUI[] waterdropsTexts;
    public TextMeshProUGUI[] diamondsTexts;

    private void Start()
    {
        UpdateShowedScores();
        UpdateShowedCurrencies();
        musicVolumeSlider.value = soundsController.musicVolume;
        soundEffectsVolumeSlider.value = soundsController.soundEffectsVolume;
    }

    public void PlayCareer(GameObject fromContainer)
    {
        fromContainer.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(ChangeScene(1, 1));
    }

    public void PlayArcade(GameObject fromContainer)
    {
        fromContainer.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(ChangeScene(2, 1));
    }

    public void PlayNoEnemies(GameObject fromContainer)
    {
        fromContainer.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(ChangeScene(3, 1));
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
        int lastScore = PlayerPrefs.GetInt("latestScore");
        lastScoreText.text = "" + lastScore;

        int highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "" + highscore;
    }

    public void UpdateShowedCurrencies()
    {
        waterdrops = PlayerPrefs.GetInt("waterdrops");
        foreach (TextMeshProUGUI waterdropsText in waterdropsTexts)
        {
            waterdropsText.text = "" + waterdrops;
        }

        diamonds = PlayerPrefs.GetInt("diamonds");
        foreach (TextMeshProUGUI diamondsText in diamondsTexts)
        {
            diamondsText.text = "" + diamonds;
        }
    }

    public void OpenWebsite()
    {
        Application.OpenURL("http://saveafricanthegame.tk/");
    }



    public void CheckSliderValue(Slider sliderToCheck)
    {
        StartCoroutine(SetVolumes());

        ChangeSliderHolderSprite(sliderToCheck);
    }

    IEnumerator SetVolumes()
    {
        yield return new WaitForSeconds(0.5f);
        soundsController.UpdateVolumes(soundEffectsVolumeSlider.value, musicVolumeSlider.value);
    }

    void ChangeSliderHolderSprite(Slider sliderToChange)
    {
        if (sliderToChange.value < 0.05f)
        {
            sliderToChange.value = 0;
            string newSliderHandleSprite = sliderToChange.targetGraphic.GetComponent<Image>().sprite.name;
            newSliderHandleSprite = newSliderHandleSprite.Remove(newSliderHandleSprite.Length - 1);
            newSliderHandleSprite += "2";

            foreach (Sprite sprite in sliderHandleSprites)
            {
                if (sprite.name == newSliderHandleSprite)
                {
                    sliderToChange.targetGraphic.GetComponent<Image>().sprite = sprite;
                }
            }
        }
        else if (sliderToChange.value < 0.6f)
        {
            string newSliderHandleSprite = sliderToChange.targetGraphic.GetComponent<Image>().sprite.name;
            newSliderHandleSprite = newSliderHandleSprite.Remove(newSliderHandleSprite.Length - 1);
            newSliderHandleSprite += "1";

            foreach (Sprite sprite in sliderHandleSprites)
            {
                if (sprite.name == newSliderHandleSprite)
                {
                    sliderToChange.targetGraphic.GetComponent<Image>().sprite = sprite;
                }
            }
        }
        else
        {
            string newSliderHandleSprite = sliderToChange.targetGraphic.GetComponent<Image>().sprite.name;
            newSliderHandleSprite = newSliderHandleSprite.Remove(newSliderHandleSprite.Length - 1);
            newSliderHandleSprite += "0";

            foreach (Sprite sprite in sliderHandleSprites)
            {
                if (sprite.name == newSliderHandleSprite)
                {
                    sliderToChange.targetGraphic.GetComponent<Image>().sprite = sprite;
                }
            }
        }
    }

    public void SaveCurrencies()
    {
        PlayerPrefs.SetInt("waterdrops", waterdrops);
        PlayerPrefs.SetInt("diamonds", diamonds);

        PlayerPrefs.Save();

        UpdateShowedCurrencies();
    }
}
