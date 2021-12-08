using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
    }
}
