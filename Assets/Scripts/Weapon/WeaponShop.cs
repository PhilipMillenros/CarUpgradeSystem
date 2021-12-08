using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private int weaponUpgradeFrequency;
    [SerializeField] private Transform[] weaponSlots;
    private readonly List<GameObject> displayedWeapons = new List<GameObject>();
    private void Start()
    {
        PlayerClient.OnAnyPlayerLevelUp += WeaponUpgradeCheck;
    }
    
    private void WeaponUpgradeCheck(PlayerClient player)
    {
        if (weaponUpgradeFrequency > 0 && player.level % weaponUpgradeFrequency == 0)
        {
            DisplayWeaponUpgrades(player);
        }
    }

    private void DisplayWeaponUpgrades(PlayerClient player)
    {
        ClearWeaponMenu();
        int weaponIndex = 0;
        for (int i = 0; i < player.gunSlots.Length; i++)
        {
            Weapon[] weapons = player.gunSlots[i].GetWeaponUpgrades();
            for (int y = 0; y < weapons.Length; y++)
            {
                displayedWeapons.Add(Instantiate(weapons[y].displayPrefab, weaponSlots[weaponIndex].transform.position,
                    Quaternion.identity, weaponSlots[weaponIndex].transform));
                weaponIndex++;
                if (weaponIndex >= weaponSlots.Length - 1)
                    break;
            }
        }
    }
    private void ClearWeaponMenu()
    {
        for (int i = 0; i < displayedWeapons.Count; i++)
        {
            Destroy(displayedWeapons[i]);
        }
        displayedWeapons.Clear();
    }

    public void BuyGun(GunSlot slot, Weapon weapon)
    {
        slot.SetGun(weapon);
    }
}
