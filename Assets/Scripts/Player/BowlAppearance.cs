using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlAppearance : MonoBehaviour
{
    Transform bowlTransform;
    public Upgrades upgrades;

    void Start()
    {
        bowlTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (upgrades.doneInitiating == true)
        {
            UpdateBowlSize();
        }
    }

    void UpdateBowlSize()
    {
        float newBowlXSize = upgrades.bowlSizeStates[upgrades.currentBowlSizeState];
        bowlTransform.localScale = new Vector2(newBowlXSize, bowlTransform.localScale.y);
    }
}
