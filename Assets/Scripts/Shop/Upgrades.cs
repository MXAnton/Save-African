using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public bool doneInitiating = false;

    string bowlSizeStateSave = "bowlSizeState";
    public float[] bowlSizeStates;
    public int currentBowlSizeState;

    private void Start()
    {
        currentBowlSizeState = PlayerPrefs.GetInt(bowlSizeStateSave);

        doneInitiating = true;
    }

    public void UpdateBowlSizeState(int newBowlSizeState)
    {
        currentBowlSizeState = newBowlSizeState;

        PlayerPrefs.SetInt(bowlSizeStateSave, currentBowlSizeState);
    }
}
