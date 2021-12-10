using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IEntity
{
    [SerializeField] private float health;
    [SerializeField] private float expGain;
    public static Action<Obstacle> OnObstacleDeath;
    public float Experience { get; set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerClient player))
        {
            TakeDamage(player.Damage, player);
        }
    }
    

    public void TakeDamage(float damage, IEntity sender)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
            sender.Experience += expGain;
        }
    }

    public void OnDeath()
    {
        OnObstacleDeath?.Invoke(this);
    }
}
