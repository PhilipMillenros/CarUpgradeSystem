using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IEntity
{
    public static Action<Obstacle> OnObstacleDeath;
    [SerializeField] private float health;
    [SerializeField] private float expGain;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerClient player)) TakeDamage(player.Damage, player);
    }

    public float Experience { get; set; }


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