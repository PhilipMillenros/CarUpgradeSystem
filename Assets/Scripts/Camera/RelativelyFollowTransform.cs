using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(0)]
public class RelativelyFollowTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float speed = 0.125f;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, speed);
    }
}
