using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrows : MonoBehaviour
{
    public float speed = 40;

    float movementX;
    float movementY;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementX = 0;
        movementY = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("up") == Input.GetKey("down"))
        {
            movementY = 0;
        }
        else
        {
            if (Input.GetKey("up"))
            {
                movementY = 1;
            }
            else
            {
                movementY = -1;
            }
        }

        if (Input.GetKey("right") == Input.GetKey("left"))
        {
            movementX = 0;
        }
        else
        {
            if (Input.GetKey("right"))
            {
                movementX = 1;
            }
            else
            {
                movementX = -1;
            }

        }
    }

     void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * speed * Time.fixedDeltaTime, movementY * speed * Time.fixedDeltaTime);
    }
}
