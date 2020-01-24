using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMovement : MonoBehaviour
{
    public GameMaster gameMaster;

    public bool useKeys = false;

    public float movementSpeed = 7f;

    public float minX = -3.6f;
    public float maxX = 3.6f;

    public float minY = -5.2f;
    public float maxY = 2.5f;

    void Update()
    {
        if (gameMaster.gamePaused == false && gameMaster.gameOn == true)
        {
            if (Input.touchCount > 0)
            {
                MoveByTouch();
            }
            else if (useKeys == true)
            {
                MoveByKeyPresses();
            }
        }
    }

    void MoveByTouch()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;

        transform.position = CheckNewWantedPosition(touchPosition);
    }

    void MoveByKeyPresses()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 newPosition = new Vector2(transform.position.x + movementSpeed * inputX * Time.deltaTime, transform.position.y + movementSpeed * inputY * Time.deltaTime);

        transform.position = CheckNewWantedPosition(newPosition);
    }

    Vector2 CheckNewWantedPosition(Vector2 position)
    {
        if (position.x < minX)
        {
            position.x = minX;
        }
        else if (position.x > maxX)
        {
            position.x = maxX;
        }
        if (position.y < minY)
        {
            position.y = minY;
        }
        else if (position.y > maxY)
        {
            position.y = maxY;
        }

        return position;
    }
}
