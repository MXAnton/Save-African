using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlying : MonoBehaviour
{
    public GameMaster gameMaster;
    public CloudController cloudController;

    public float minYSpawnPos;
    public float maxYSpawnPos;

    public bool directionRight;
    public float birdSpeedMultiplier = 2;
    public float flyingSpeed;

    private void Start()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

        flyingSpeed -= Random.Range(cloudController.waterdropMovementSpeed - 0.1f, cloudController.waterdropMovementSpeed + 0.1f);
        flyingSpeed *= birdSpeedMultiplier;
    }

    void Update()
    {
        if (gameMaster.gamePaused == false && gameMaster.gameOn == true)
        {
            if (directionRight == false)
            {
                transform.position = new Vector2(transform.position.x - flyingSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + flyingSpeed * Time.deltaTime, transform.position.y);
            }
        }

        if (transform.position.x < -5 || transform.position.x > 5)
        {
            Destroy(gameObject);
        }
    }
}
