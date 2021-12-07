using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public float Health { get; set; }
    public float Armor { get; set; }
    public float Damage { get; set; }
    public void TakeDamage(float damage);
    public void OnDeath();
}
