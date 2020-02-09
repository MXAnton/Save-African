using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    CloudController cloudController;
    public UIController uiController;

    public string catsAndDogsAmountSave = "catsAndDogsAmount";
    public float catsAndDogsAmount; // 0-100
    public bool rainingCatsAndDogs = false;
    //[Space]
    //public float catsAndDogsSpawnDelayDuplicator = 1; // 1-0
    [Space]
    public float catsAndDogsLoadSpeed = 0.5f;
    public float catsAndDogsLoadSpeedDuplicator = 1; // 1-10000
    [Space]
    public float catsAndDogsUnloadSpeed = 1f;
    public float catsAndDogsUnloadSpeedDuplicator = 1; // 1-10000
    [Space]
    public float boostAmount = 2f; // 1-10000


    void Start()
    {
        cloudController = GetComponent<CloudController>();

        catsAndDogsAmount = PlayerPrefs.GetFloat(catsAndDogsAmountSave);
        uiController.UpdateCatsAndDogsSliders(catsAndDogsAmount / 100);
    }

    void Update()
    {
        if (catsAndDogsAmount >= 100 || rainingCatsAndDogs == true)
        {
            catsAndDogsAmount -= catsAndDogsUnloadSpeed / catsAndDogsUnloadSpeedDuplicator * Time.deltaTime;

            if (catsAndDogsAmount <= 0)
            {
                rainingCatsAndDogs = false;
                cloudController.currentDirtyWaterSpawnRate = cloudController.dirtyWaterSpawnRate;
                cloudController.currentBirdSpawnRate = cloudController.birdSpawnRate;
                cloudController.currentDiamondSpawnRate = cloudController.diamondSpawnRate;
            }

            uiController.UpdateCatsAndDogsSliders(catsAndDogsAmount / 100);
        }
        else
        {
            cloudController.currentSpawnDelay = cloudController.waterdropSpawnDelay;
        }
    }

    public void AddCatsAndDogsAmount(int amount)
    {
        if (rainingCatsAndDogs == false)
        {
            catsAndDogsAmount += amount * catsAndDogsLoadSpeedDuplicator * catsAndDogsLoadSpeed;
            cloudController.currentSpawnDelay = cloudController.waterdropSpawnDelay;

            if (catsAndDogsAmount >= 100)
            {
                catsAndDogsAmount = 100;

                rainingCatsAndDogs = true;
                cloudController.currentDirtyWaterSpawnRate = 0;
                cloudController.currentBirdSpawnRate = 0;
                cloudController.currentDiamondSpawnRate = cloudController.diamondSpawnRate * boostAmount;
                cloudController.currentSpawnDelay = cloudController.waterdropSpawnDelay / boostAmount;
            }
            uiController.UpdateCatsAndDogsSliders(catsAndDogsAmount / 100);
        }
    }
}
