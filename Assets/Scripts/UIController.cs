using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameMaster gameMaster;

    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "" + gameMaster.score;
    }
}
