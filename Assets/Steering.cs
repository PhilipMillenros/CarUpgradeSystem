using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    [SerializeField] private Transform[] frontWheels;
    [SerializeField] private float maxSteeringAngle;
    public float steeringAngle;
    private float steering;
    [SerializeField] private float turnSpeed = 20f;

    public void SetSteering(float horizontal, float vertical)
    {
        if (horizontal == 0)
        {
            if (steeringAngle > 0)
                steeringAngle -= turnSpeed * Time.deltaTime;
            else
                steeringAngle += turnSpeed * Time.deltaTime;
        }
        else
            steeringAngle += turnSpeed * horizontal * Time.deltaTime;
        steeringAngle = Mathf.Clamp(steeringAngle, -maxSteeringAngle, maxSteeringAngle);
        float newRotation = horizontal * turnSpeed * Time.deltaTime * vertical;
        transform.Rotate(0, newRotation, 0, Space.World);
        for (int i = 0; i < frontWheels.Length; i++)
        {
           // frontWheels[i].rotation = Quaternion.Euler(0, steeringAngle, 0);
            
        }
    }
}
