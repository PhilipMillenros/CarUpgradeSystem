using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IEntity
{
    public float maxHealth;
    public float regen;
    public float experience;
    public float experienceThreshold;
    public float fireRate;
    public float Health { get; set; }
    public float Armor { get; set; }
    public float Damage { get; set; }
    public int skillPoints;
    public int level;
    public static Action<PlayerStats> OnAnyPlayerLevelUp;
    

    private void Awake()
    {
        Health = maxHealth;
    }

    public void GainExp(float amount)
    {
        experience += amount;
        if (experience > experienceThreshold)
        {
            OnAnyPlayerLevelUp.Invoke(this);
        }
    }
    public void TakeDamage(float damage)
    {
        if(Armor >= damage)
            return;
        Health -= (damage - Armor);
        if (Health <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
