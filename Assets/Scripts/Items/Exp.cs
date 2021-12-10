using System;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public static Action<Exp> OnExpPickup;
    [SerializeField] private float exp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerClient player))
        {
            player.GainExp(exp);
            OnExpPickup?.Invoke(this);
        }
    }
}