using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor : MonoBehaviour
{
    [SerializeField] private Transform[] wheelObjects;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float reverseSpeed;
    [SerializeField] private Rigidbody sphereRB;
    private float moveInput = 0;

    private void Start()
    {
        sphereRB.transform.parent = null;
    }

    public void Thrust(float controllerInput)
    {
        moveInput = controllerInput * (controllerInput > 0 ? forwardSpeed : reverseSpeed);

        transform.position = sphereRB.transform.position;
    }

    private void FixedUpdate()
    {
        if (moveInput == 0)
        {
            return;
        }
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
