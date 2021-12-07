using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMark : MonoBehaviour
{
    [SerializeField] private TrailRenderer[] skidMarkTrails;
    public void SetSkidEmitter(bool isEmitting)
    {
        for (int i = 0; i < skidMarkTrails.Length; i++)
        {
            skidMarkTrails[i].emitting = isEmitting;
        }
    }
}
