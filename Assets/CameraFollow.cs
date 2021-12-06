using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float damping = 1;

    private void Awake()
    {
        offset = target.position - transform.position;
    }

    private void Update()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
         
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - (rotation * offset);
         
        transform.LookAt(target.transform);
    }
}
