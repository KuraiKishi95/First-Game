using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCo : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    private Vector2 movementInput;
    bool jump = false;
    bool crouch = false;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    void FixedUpdate()
    {
        horizontalMove = movementInput.x * runSpeed;
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, crouch, jump);

        Debug.Log(movementInput.x);
        //transform.Translate(new Vector2(movementInput.x, movementInput.y) * runSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
