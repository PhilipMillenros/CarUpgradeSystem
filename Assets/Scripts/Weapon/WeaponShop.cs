using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private int weaponUpgradeFrequency;
    [SerializeField] private Transform[] weaponSlots;
    private readonly List<GameObject> displayedWeapons = new List<GameObject>();
    private List<Button> buttons = new List<Button>();
    private void Start()
    {
        PlayerClient.OnAnyPlayerLevelUp += WeaponUpgradeCheck;
        AddShopButtons();
        ClearWeaponMenu();
    }
    private void WeaponUpgradeCheck(PlayerClient player)
    {
        if (player.level % weaponUpgradeFrequency == 0)
        {
            player.weaponUpgrades++;
        }
        if (player.weaponUpgrades > 0)
        {
            DisplayWeaponUpgrades(player);
        }
        else
            ClearWeaponMenu();
    }

    private void DisplayWeaponUpgrades(PlayerClient player)
    {
        ClearWeaponMenu();
        int weaponIndex = 0;
        for (int i = 0; i < player.gunSlots.Length; i++)
        {
            Weapon[] weaponUpgrades = player.gunSlots[i].GetWeaponUpgrades();
            for (int y = 0; y < weaponUpgrades.Length; y++)
            {
                displayedWeapons.Add(Instantiate(weaponUpgrades[y].displayPrefab, weaponSlots[weaponIndex].transform.position,
                    Quaternion.identity, weaponSlots[weaponIndex].transform));
                weaponSlots[weaponIndex].gameObject.SetActive(true);
                int gunSlot = i;
                int weapon = y;
                buttons[weaponIndex].onClick.AddListener(delegate { BuyGun(player.gunSlots[gunSlot], 
                    Instantiate(weaponUpgrades[weapon].gameObject).GetComponent<Weapon>(), player); });
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
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            weaponSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
        displayedWeapons.Clear();
    }
    private void AddShopButtons()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            buttons.Add(weaponSlots[i].GetComponentInChildren<Button>());
        }
    }
    public void BuyGun(GunSlot slot, Weapon weapon, PlayerClient player)
    {
        player.weaponUpgrades--;
        slot.SetGun(weapon);
        if(player.weaponUpgrades < 1)
            ClearWeaponMenu();
        else
        {
            ClearWeaponMenu();
            DisplayWeaponUpgrades(player);
        }
    }
}
