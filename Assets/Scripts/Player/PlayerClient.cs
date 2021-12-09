using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClient : MonoBehaviour, IEntity
{
    [HideInInspector] public float experience;
    [HideInInspector] public float experienceThreshold;
    [SerializeField] public int skillPoints;
    [SerializeField] private float regenerationInterval;
    public static Action<PlayerClient> OnAnyPlayerLevelUp;
    
    public float regeneration;
    public float reloadTime;
    public float maxHealth;
    public GunSlot[] gunSlots;
    public int weaponUpgrades;
    public int level;
    public float Health { get; set; }
    public float Armor { get; set; }
    public float Damage { get; set; }

    private void Awake()
    {
        Health = maxHealth;
        Regenerate();
    }
    public void GainExp(float amount)
    {
        experience += amount;
        if (experience > experienceThreshold)
        {
            OnAnyPlayerLevelUp.Invoke(this);
        }
    }
    private void Regenerate()
    {
        if (Health >= maxHealth) return;
        Health += regeneration;
        CallbackTimer.AddTimer(regenerationInterval, Regenerate);
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
