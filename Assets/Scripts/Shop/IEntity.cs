using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public float Experience { get; set; }
    public void TakeDamage(float damage, IEntity sender);
    public void OnDeath();
}
