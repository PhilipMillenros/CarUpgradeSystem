using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    [SerializeField] private WheelCollider[] frontWheels;
    [SerializeField] private float maxSteeringAngle;
    public float steeringAngle;
    
    public void SetSteering(float input)
    {
        steeringAngle = maxSteeringAngle * input;
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].steerAngle = steeringAngle;
        }
    }
}
