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
    [Space]
    public float accelerationSpeed = 0.01f;
    [Space]
    public float dirtyWaterSpawnRate = 0.1f; // 0-1
    public float birdSpawnRate = 0.05f; // 0-1

    void Start()
    {
        waterdropMovementSpeed = startWaterdropMovementSpeed;
        waterdropSpawnDelay = startWaterdropSpawnDelay;

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

                if (whichObjectToSpawn <= dirtyWaterSpawnRate)
                {
                    newWaterdrop = Instantiate(waterdropDirty, new Vector2(Random.Range(minX, maxX), spawnYPosition), Quaternion.identity);

                    newWaterdrop.GetComponent<WaterdropController>().cloudController = this;
                }
                else
                {
                    newWaterdrop = Instantiate(waterdrop, new Vector2(Random.Range(minX, maxX), spawnYPosition), Quaternion.identity);

                    newWaterdrop.GetComponent<WaterdropController>().cloudController = this;
                }

                if (whichObjectToSpawn <= dirtyWaterSpawnRate + birdSpawnRate)
                {
                    float direction = Random.Range(0f, 1f);

                    if (direction < 0.5f)
                    {
                        newWaterdrop = Instantiate(bird, new Vector2(-5, spawnYPosition), Quaternion.identity);
                        newWaterdrop.GetComponent<BirdFlying>().directionRight = false;
                    }
                    else
                    {
                        newWaterdrop = Instantiate(bird, new Vector2(5, spawnYPosition), Quaternion.identity);
                        newWaterdrop.GetComponent<BirdFlying>().directionRight = true;
                    }

                    float newYPosition = Random.Range(newWaterdrop.GetComponent<BirdFlying>().minYSpawnPos,
                                                    newWaterdrop.GetComponent<BirdFlying>().maxYSpawnPos);
                    newWaterdrop.transform.position = new Vector2(newWaterdrop.transform.position.x, newYPosition);

                    newWaterdrop.GetComponent<BirdFlying>().cloudController = this;
                    newWaterdrop.GetComponent<BirdPoop>().cloudController = this;
                }

                yield return new WaitForSeconds(waterdropSpawnDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
