﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool gameOn = true;
    public bool gamePaused = false;

    public int score;

    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}