using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    //public GameObject main;
    //public GameObject highscores;
    //public GameObject upgrades;
    //public GameObject shop;
    //public GameObject settings;

    public GameObject toContainer;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeMenuContainer(GameObject fromContainer)
    {
        fromContainer.GetComponent<Animator>().SetTrigger("Out");
        toContainer.SetActive(true);
        StartCoroutine(DisableMenuContainer(fromContainer, 1));
    }

    IEnumerator DisableMenuContainer(GameObject whichGameObject, float time)
    {
        yield return new WaitForSeconds(time);
        whichGameObject.SetActive(false);
    }

    public void SetToContainer(GameObject newToContainer)
    {
        toContainer = newToContainer;
    }
}
