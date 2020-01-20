using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementMargin;

    public Transform bowlTransform;

    void Update()
    {
        //float yDistance = -bowlTransform.position.y;
        if (bowlTransform.position.x < transform.position.x - movementMargin)
        {
            transform.position = new Vector2(bowlTransform.position.x + movementMargin, transform.position.y);
        }
        else if (bowlTransform.position.x > transform.position.x + movementMargin)
        {
            transform.position = new Vector2(bowlTransform.position.x - movementMargin, transform.position.y);
        }
    }
}
