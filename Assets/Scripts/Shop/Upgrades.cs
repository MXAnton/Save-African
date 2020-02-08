using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public bool doneInitiating = false;

    string bowlSizeStateSave = "bowlSizeState";
    public float[] bowlSizeStates;
    public int currentBowlSizeState;

    string catchBonusStateSave = "catchBonusState";
    public float[] catchBonusStates;
    public int currentCatchBonusState; // Nästa, lägg till catchBonus till skålen

    private void Start()
    {
        currentBowlSizeState = PlayerPrefs.GetInt(bowlSizeStateSave);
        currentCatchBonusState = PlayerPrefs.GetInt(catchBonusStateSave);

        doneInitiating = true;
    }
}
