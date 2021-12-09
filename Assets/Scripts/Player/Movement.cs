using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 11f;
    private Vector2 horizontalInput;
    [SerializeField] private float jumpHeight = 3.5f;
    private bool jump;
    [SerializeField] private float gravity = -30f;
    private Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }
        
        verticalVelocity.y += gravity * Time.deltaTime;
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void Jump()
    {
        jump = true;
    }
}
