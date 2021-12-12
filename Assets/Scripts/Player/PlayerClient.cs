using System;
using UnityEngine;
using Vehicle;

public class PlayerClient : MonoBehaviour, IEntity
{
    public static Action<PlayerClient> OnAnyPlayerLevelUp;
    [HideInInspector] public float experienceThreshold;
    [SerializeField] public int skillPoints;
    [SerializeField] private float regenerationInterval;

    public float regeneration;
    public float reloadTime;
    public float maxHealth;
    public GunSlot[] gunSlots;
    public int weaponUpgrades;
    public int level;
    public float Health { get; set; }
    public float Armor { get; set; }
    public float Damage { get; set; }
    [SerializeField] private CarMotor carMotor;
    [SerializeField] private PlayerCarController carController;
    [SerializeField] private Steering steering;
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
        Health = maxHealth;
        carMotor.SetMotor(carController, rb);
        steering.SetSteering(carController);
        
        Regenerate();
    }

    public float Experience { get; set; }

    public void TakeDamage(float damage, IEntity sender)
    {
        if (Armor >= damage)
            return;
        Health -= damage - Armor;
        if (Health <= 0) OnDeath();
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public void GainExp(float amount)
    {
        Experience += amount;
        if (Experience > experienceThreshold) OnAnyPlayerLevelUp.Invoke(this);
    }

    private void Regenerate()
    {
        if (Health >= maxHealth) return;
        Health += regeneration;
        CallbackTimer.AddTimer(regenerationInterval, Regenerate);
    }
}