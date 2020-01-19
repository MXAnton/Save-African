using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 7f;

    public float minX = -3.6f;
    public float maxX = 3.6f;

    public float minY = -5.2f;
    public float maxY = 2.5f;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 newPosition = new Vector2(transform.position.x + movementSpeed * inputX * Time.deltaTime, transform.position.y + movementSpeed * inputY * Time.deltaTime);

        if (newPosition.x < minX)
        {
            newPosition.x = minX;
        }
        else if (newPosition.x > maxX)
        {
            newPosition.x = maxX;
        }
        if (newPosition.y < minY)
        {
            newPosition.y = minY;
        }
        else if (newPosition.y > maxY)
        {
            newPosition.y = maxY;
        }

        //transform.position = newPosition;
        GetComponent<Rigidbody2D>().AddForce(transform.up * 20);
    }
}
