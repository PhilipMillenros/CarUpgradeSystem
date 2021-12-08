using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public void TakeDamage(float damage);
    public void OnDeath();
}
