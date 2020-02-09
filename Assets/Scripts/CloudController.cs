using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameMaster gameMaster;
    [Space]
    public GameObject waterdrop;
    public GameObject waterdropDirty;
    public GameObject bird;
    public GameObject diamond;

    public float spawnYPosition = 4.5f;
    public float minX = -3;
    public float maxX = 3;

    [Header("Movement/Spawning rate")]
    public float startWaterdropMovementSpeed = 1.4f;
    public float maxWaterdropMovementSpeed = 6f;
    public float waterdropMovementSpeed;
    [Space]
    public float startWaterdropSpawnDelay = 4f;
    public float minWaterdropSpawnDelay = 0.2f;
    public float waterdropSpawnDelay;
    public float currentSpawnDelay;
    [Space]
    public float accelerationSpeed = 0.01f;
    [Space]
    public float dirtyWaterSpawnRate = 0.1f; // 0-1
    public float birdSpawnRate = 0.05f; // 0-1
    public float diamondSpawnRate = 0.007f; // 0-1
    [Space]
    public float currentDirtyWaterSpawnRate = 0.1f; // 0-1
    public float currentBirdSpawnRate = 0.05f; // 0-1
    public float currentDiamondSpawnRate = 0.007f; // 0-1

    void Start()
    {
        waterdropMovementSpeed = startWaterdropMovementSpeed;
        waterdropSpawnDelay = startWaterdropSpawnDelay;
        currentSpawnDelay = waterdropSpawnDelay;

        StartCoroutine(SpawnWaterdrop());
    }

    void Update()
    {
        if (gameMaster.gamePaused == false && gameMaster.gameOn == true)
        {
            if (waterdropMovementSpeed < maxWaterdropMovementSpeed)
            {
                waterdropMovementSpeed += accelerationSpeed * Time.deltaTime;
            }
            if (waterdropSpawnDelay > minWaterdropSpawnDelay)
            {
                waterdropSpawnDelay -= accelerationSpeed * Time.deltaTime;
            }
        }
    }

    IEnumerator SpawnWaterdrop()
    {
        yield return new WaitForSeconds(waterdropSpawnDelay / 2);

        while(gameMaster.gameOn)
        {
            if (gameMaster.gamePaused == false)
            {
                GameObject newWaterdrop;
                float whichObjectToSpawn = Random.Range(0f, 1f);
                float xSpawnPosition = Random.Range(minX, maxX);
                xSpawnPosition = Mathf.Round(xSpawnPosition * 2.5f) / 2.5f;

                if (whichObjectToSpawn <= currentDirtyWaterSpawnRate)
                {
                    newWaterdrop = Instantiate(waterdropDirty, new Vector2(xSpawnPosition, spawnYPosition), Quaternion.identity);

                    newWaterdrop.GetComponent<WaterdropController>().cloudController = this;
                }
                else
                {
                    newWaterdrop = Instantiate(waterdrop, new Vector2(xSpawnPosition, spawnYPosition), Quaternion.identity);

                    newWaterdrop.GetComponent<WaterdropController>().cloudController = this;
                }


                if (whichObjectToSpawn >= 1 - currentBirdSpawnRate)
                {
                    SpawnBird();
                }
                else if (whichObjectToSpawn >= 1 - currentBirdSpawnRate - currentDiamondSpawnRate)
                {
                    GameObject newDiamond = Instantiate(diamond, new Vector2(xSpawnPosition, spawnYPosition), Quaternion.identity);

                    newDiamond.GetComponent<WaterdropController>().cloudController = this;
                }

                yield return new WaitForSeconds(currentSpawnDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void SpawnBird()
    {
        GameObject newBird;
        float direction = Random.Range(0f, 1f);

        if (direction < 0.5f)
        {
            newBird = Instantiate(bird, new Vector2(-5, spawnYPosition), Quaternion.identity);
            newBird.GetComponent<BirdFlying>().directionRight = false;
        }
        else
        {
            newBird = Instantiate(bird, new Vector2(5, spawnYPosition), Quaternion.identity);
            newBird.GetComponent<BirdFlying>().directionRight = true;
        }

        float newYPosition = Random.Range(newBird.GetComponent<BirdFlying>().minYSpawnPos,
                                        newBird.GetComponent<BirdFlying>().maxYSpawnPos);
        newBird.transform.position = new Vector2(newBird.transform.position.x, newYPosition);

        newBird.GetComponent<BirdFlying>().cloudController = this;
        newBird.GetComponent<BirdPoop>().cloudController = this;
    }
}
