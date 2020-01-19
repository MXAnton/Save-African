using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdropController : MonoBehaviour
{
    public GameMaster gameMaster;
    public CloudController cloudController;

    float movementSpeed;

    void Start()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

        movementSpeed = Random.Range(cloudController.waterdropMovementSpeed - 0.1f, cloudController.waterdropMovementSpeed + 0.1f);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bowl")
        {
            gameMaster.AddScore(1);
            Destroy(gameObject);
        }
    }
}
