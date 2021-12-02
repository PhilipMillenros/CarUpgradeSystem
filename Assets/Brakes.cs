using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakes : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private float breakForce;
    public void Break()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].brakeTorque = breakForce;
        }
    }
}
