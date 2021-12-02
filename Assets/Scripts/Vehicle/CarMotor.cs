using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private Transform[] wheelObjects;
    [SerializeField] private float force;
    public void Thrust(float controllerInput)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = force * controllerInput;
        }
    }

    private void Update()
    {
        UpdatePhyisicalWheels();
    }

    private void UpdatePhyisicalWheels()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            Vector3 position;
            Quaternion rotation;
            wheels[i].GetWorldPose(out position, out rotation);
            wheelObjects[i].rotation = rotation;
            wheelObjects[i].position = position;
        }
    }
}
