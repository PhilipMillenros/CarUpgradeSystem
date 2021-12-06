using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativelyFollowTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float speed = 0.125f;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
