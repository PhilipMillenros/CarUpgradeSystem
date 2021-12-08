using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 axis;
    private void Update()
    {
        transform.Rotate((Time.deltaTime * rotateSpeed) * axis.x,
            (Time.deltaTime * rotateSpeed) * axis.y, (Time.deltaTime * rotateSpeed) * axis.z);
    }
}
