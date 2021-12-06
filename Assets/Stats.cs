using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float regen;
    public float damage;
    public float armor;
    public float experience;
    public float fireRate;

    public void TakeDamage(float damage)
    {
        if(armor >= damage)
            return;
        health -= (damage - armor);
    }
}
