using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float movementMargin;

    public Transform bowlTransform;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //float yDistance = -bowlTransform.position.y;
        if (bowlTransform.position.x < transform.position.x - movementMargin)
        {
            rb2d.MovePosition(new Vector2(bowlTransform.position.x + movementMargin, transform.position.y));
            //transform.position = new Vector2(bowlTransform.position.x + movementMargin, transform.position.y);
        }
        else if (bowlTransform.position.x > transform.position.x + movementMargin)
        {
            rb2d.MovePosition(new Vector2(bowlTransform.position.x - movementMargin, transform.position.y));
            //transform.position = new Vector2(bowlTransform.position.x - movementMargin, transform.position.y);
        }
    }
}
