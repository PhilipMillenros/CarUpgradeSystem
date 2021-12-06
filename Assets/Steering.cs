using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Steering : MonoBehaviour
{
    [SerializeField] private Transform[] frontWheels;
    [SerializeField] private float maxSteeringAngle;
    public float wheelAngle;
    private float steering;
    [SerializeField] private float turnBackSpeed = 5f;
    [SerializeField] private float wheelTurningSpeed = 20f;
    [SerializeField] private float maxTurningSpeed = 50f;
    [SerializeField] private float turningSpeed = 0.5f;
    [SerializeField] private SkidMark skidMark;
    [SerializeField] private float skidMarkThreshold;

    [SerializeField] private float currentTurnSpeed;

    public void SetSteering(Vector2 input)
    {
        SteerCar(input);
        SteerWheels(input);
    }
    private void SteerWheels(Vector2 input)
    {
        if (input.x == 0)
        {
            wheelAngle = Mathf.Lerp(wheelAngle, 0, Time.deltaTime * turnBackSpeed);
        }
        else
            wheelAngle += wheelTurningSpeed * input.x * Time.deltaTime;
        wheelAngle = Mathf.Clamp(wheelAngle, -maxSteeringAngle, maxSteeringAngle);

        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].localRotation = Quaternion.Euler(0, 0, wheelAngle);
        }
    }
    private void SteerCar(Vector2 input)
    {
        if (input.y == 0)
        {
            currentTurnSpeed = 0;
            return;
        }
        currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, maxTurningSpeed * input.x, turningSpeed * Time.deltaTime);
        if((input.y > 0 && (Mathf.Abs(maxTurningSpeed) - Mathf.Abs(currentTurnSpeed)) < skidMarkThreshold))
            skidMark.SetSkidEmitter(true);
        else
            skidMark.SetSkidEmitter(false);

        transform.Rotate(0, currentTurnSpeed, 0, Space.World);
    }
}
