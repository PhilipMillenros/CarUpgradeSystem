using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IEntity
{
    public float maxHealth;
    public float regen;
    public float experience;
    public float fireRate;
    
    public float Health { get; set; }
    public float Armor { get; set; }
    public float Damage { get; set; }

    private void Awake()
    {
        Health = maxHealth;
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
