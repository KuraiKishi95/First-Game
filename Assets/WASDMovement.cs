using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;

    const float L_BOARDER = -50.76f;
    const float R_BOARDER = 71.96f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("WASDMovementHorizontal") * runSpeed;
        //verticalMove = Input.GetAxisRaw("WASDMovementVertical") * runSpeed;

        if (Input.GetButtonDown("WASDJump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("WASDCrouch"))
        {
            crouch = true;
        }

        else if (Input.GetButtonUp("WASDCrouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("WASDDash"))
        {
            WASDDash();
        }
    }

    void FixedUpdate()
    {

        if (transform.position.x <= L_BOARDER)
        {
            transform.SetPositionAndRotation(new Vector2(transform.position.x + 122.72f, transform.position.y), transform.rotation);
        }

        if (transform.position.x >= R_BOARDER)
        {
            transform.SetPositionAndRotation(new Vector2(transform.position.x - 122.72f, transform.position.y), transform.rotation);
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }

    public void WASDDash()
    {
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            AddForceAtAngle(8000f, 45);
        }

        else if (Input.GetKey("w") && Input.GetKey("a"))
        {
            AddForceAtAngle(8000f, 135);
        }

        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            AddForceAtAngle(8000f, -45);
        }

        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            AddForceAtAngle(8000f, -135);
        }

        else if (Input.GetKey("w"))
        {
            rb.AddForce(new Vector2(0f, 8000f));

        }

        else if (Input.GetKey("s"))
        {
            rb.AddForce(new Vector2(0f, -8000f));
        }

        else if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(8000f, 0f));
        }

        else if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-8000f, 0f));
        }

    }

    public void AddForceAtAngle(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;

        rb.AddForce(new Vector2(xcomponent, ycomponent));
    }


}
