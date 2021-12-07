using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private float exp;
    public static Action<Exp> OnExpPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Stats stats))
        {
            stats.experience += exp;
            OnExpPickup?.Invoke(this);
        }
    }
}
