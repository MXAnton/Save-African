using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameMaster gameMaster;

    public GameObject waterdrop;

    public float spawnYPosition = 4.5f;
    public float minX = -3;
    public float maxX = 3;

    public float startWaterdropMovementSpeed = 1f;
    public float waterdropMovementSpeed;

    public float startWaterdropSpawnDelay = 0.5f;
    public float waterdropSpawnDelay;

    void Start()
    {
        waterdropMovementSpeed = startWaterdropMovementSpeed;
        waterdropSpawnDelay = startWaterdropSpawnDelay;

        StartCoroutine(SpawnWaterdrop());
    }

    void Update()
    {
        waterdropMovementSpeed = waterdropMovementSpeed + 0.001f * waterdropMovementSpeed * 5 * Time.deltaTime;
        waterdropSpawnDelay = waterdropSpawnDelay - 0.05f / waterdropSpawnDelay / 2 * Time.deltaTime;
    }

    IEnumerator SpawnWaterdrop()
    {
        yield return new WaitForSeconds(waterdropSpawnDelay / 2);

        while(gameMaster.gameOn)
        {
            if (gameMaster.gamePaused == false)
            {
                GameObject newWaterdrop = Instantiate(waterdrop, new Vector2(Random.Range(minX, maxX), spawnYPosition), Quaternion.identity);
                newWaterdrop.GetComponent<WaterdropController>().cloudController = this;
                yield return new WaitForSeconds(waterdropSpawnDelay);
            }
        }
    }
}
