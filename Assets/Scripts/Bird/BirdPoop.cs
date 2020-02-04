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
        dropPosition = Mathf.Round(dropPosition * 2.5f) / 2.5f;

        if (dropPosition > minX)
        {
            dropPosition -= 0.2f;
        }
        else
        {
            dropPosition += 0.2f;
        }
    }

    void Update()
    {
        if (transform.position.x > dropPosition - 0.06f && transform.position.x < dropPosition + 0.06f && hasDropped == false)
        {
            DropPoop();
        }
    }

    void DropPoop()
    {
        hasDropped = true;
        GameObject newBirdPoop = Instantiate(birdPoop, new Vector2(dropPosition, transform.position.y - 0.1f), Quaternion.identity);
        newBirdPoop.GetComponent<WaterdropController>().cloudController = cloudController;
    }
}
