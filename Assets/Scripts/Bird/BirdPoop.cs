using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPoop : MonoBehaviour
{
    public CloudController cloudController;

    public GameObject birdPoop;

    public float minX;
    public float maxX;

    public float dropPosition;

    public bool hasDropped = false;

    private void Start()
    {
        minX = cloudController.minX;
        maxX = cloudController.maxX;
        dropPosition = Random.Range(minX, maxX);
    }

    void Update()
    {
        if (transform.position.x > dropPosition - 0.03f && transform.position.x < dropPosition + 0.03f && hasDropped == false)
        {
            DropPoop();
        }
    }

    void DropPoop()
    {
        hasDropped = true;
        GameObject newBirdPoop = Instantiate(birdPoop, new Vector2(transform.position.x, transform.position.y - 0.1f), Quaternion.identity);
        newBirdPoop.GetComponent<WaterdropController>().cloudController = cloudController;
    }
}
