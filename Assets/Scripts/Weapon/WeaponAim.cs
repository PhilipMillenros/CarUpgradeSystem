using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAim : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Transform weapon;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out hit)) 
        {
            weapon.LookAt(hit.point + (Vector3.up * (weapon.transform.position.y - hit.point.y)));
        }
    }
}
