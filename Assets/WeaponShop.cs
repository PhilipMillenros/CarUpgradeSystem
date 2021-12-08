using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private int weaponUpgradeFrequency;
    private void Start()
    {
        PlayerClient.OnAnyPlayerLevelUp += SufficientPlayerLevelCheck;
    }

    private void SufficientPlayerLevelCheck(PlayerClient player)
    {
        if (weaponUpgradeFrequency > 0 && player.level % weaponUpgradeFrequency == 0)
        {
            DisplayWeaponUpgrades(player);
        }
    }

    private void DisplayWeaponUpgrades(PlayerClient player)
    {
        for (int i = 0; i < player.gunSlots.Length; i++)
        {
            Weapon[] weapons = player.gunSlots[i].GetWeaponUpgrades();
            for (int y = 0; y < weapons.Length; y++)
            {
                
            }
        }
    }

    public void BuyGun(GunSlot slot, Weapon weapon)
    {
        slot.SetGun(weapon);
    }
}
