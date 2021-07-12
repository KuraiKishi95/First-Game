using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;
    //int dashCounter = 2;
    public float cooldownTime = 3;
    public float cooldownEndTime = 0;

    public const float L_BOARDER = -50.76f;
    public const float R_BOARDER = 71.96f;

    private Rigidbody2D rb;

    PlayerControls controls;
    Vector2 move;
    bool dash;

    //[SerializeField] public  BoxCollider2D leftTopGap;
    //[SerializeField] public BoxCollider2D leftBotGap;

    // Update is called once per frame

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //controls = new PlayerControls();
        //controls.Gameplay.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        //controls.Gameplay.Move.canceled += ctx => Stop();
    }

    //void Move(Vector2 direction)
    //{
    //    //move = direction;
    //    //Vector2 m = new Vector2(direction.x, direction.y) * Time.deltaTime;
    //    //transform.Translate(m, Space.World);

    //    horizontalMove = direction.x * runSpeed;

    //    controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, crouch, jump);

    //}


    //void Stop()
    //{
    //    horizontalMove = 0f;
    //    controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, crouch, jump);
    //}

    public void OnMove(InputAction.CallbackContext ctx) => move = ctx.ReadValue<Vector2>();

    public void OnDash(InputAction.CallbackContext ctx)
    {
        dash = ctx.ReadValueAsButton();
        ArrowsDash(dash, move);
    }

    public void OnJump(InputAction.CallbackContext ctx) => jump = true;
    public void OnCrouch(InputAction.CallbackContext ctx) => crouch = false;


    void Update()
    {
        horizontalMove = move.x * runSpeed;


        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        ////verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;



        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //}

        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //}

        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}

        //if (Time.time > cooldownEndTime)
        //{
        //    if (dashCounter > 0)
        //    {
        //        if (Input.GetButtonDown("Dash"))
        //        {
        //            ArrowsDash();
        //            print(dashCounter);
        //            dashCounter--;
        //        }

        //        //if (Time.time - cooldownEndTime == 3)
        //        //{
        //        //    dashCounter++;
        //        //}

        //    }
        //    else
        //    {
        //        cooldownEndTime = Time.time + cooldownTime;
        //        print(dashCounter);
        //        dashCounter = 2;

        //    }
        //}
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

    //void OnEnable()
    //{
    //    controls.Gameplay.Enable();
    //}

    //void OnDisable()
    //{
    //    controls.Gameplay.Disable();
    //}

    public void ArrowsDash(bool dash, Vector2 move)
    {
        if (dash)
        {
            if (move.y > 0 && move.x > 0)
            {
                AddForceAtAngle(8000f, 45);
            }

            else if (move.y > 0 && move.x < 0)
            {
                AddForceAtAngle(8000f, 135);
            }

            else if (move.y < 0 && move.x > 0)
            {
                AddForceAtAngle(8000f, -45);
            }

            else if (move.y < 0 && move.x < 0)
            {
                AddForceAtAngle(8000f, -135);
            }

            else if (move.y > 0)
            {
                rb.AddForce(new Vector2(0f, 8000f));
            }

            else if (move.y < 0)
            {
                rb.AddForce(new Vector2(0f, -8000f));
            }

            else if (move.x > 0)
            {
                rb.AddForce(new Vector2(8000f, 0f));
            }

            else if (move.x < 0)
            {
                rb.AddForce(new Vector2(-8000f, 0f));
            }
        }
        dash = false;
    }

    public void AddForceAtAngle(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;

        rb.AddForce(new Vector2(xcomponent, ycomponent));
    }
}
