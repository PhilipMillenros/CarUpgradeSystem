using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private int weaponUpgradeFrequency;
    [SerializeField] private Transform[] weaponSlots;
    private readonly List<GameObject> displayedWeapons = new();
    private readonly List<Button> buttons = new();

    private void Start()
    {
        PlayerClient.OnAnyPlayerLevelUp += WeaponUpgradeCheck;
        AddShopButtons();
        ClearWeaponMenu();
    }

    private void WeaponUpgradeCheck(PlayerClient player)
    {
        if (player.level % weaponUpgradeFrequency == 0) player.weaponUpgrades++;
        if (player.weaponUpgrades > 0)
            DisplayWeaponUpgrades(player);
        else
            ClearWeaponMenu();
    }

    private void DisplayWeaponUpgrades(PlayerClient player)
    {
        ClearWeaponMenu();
        var weaponIndex = 0;
        for (var i = 0; i < player.gunSlots.Length; i++)
        {
            var weaponUpgrades = player.gunSlots[i].GetWeaponUpgrades();
            for (var y = 0; y < weaponUpgrades.Length; y++)
            {
                displayedWeapons.Add(Instantiate(weaponUpgrades[y].displayPrefab,
                    weaponSlots[weaponIndex].transform.position,
                    Quaternion.identity, weaponSlots[weaponIndex].transform));
                weaponSlots[weaponIndex].gameObject.SetActive(true);
                var gunSlot = i;
                var weapon = y;
                buttons[weaponIndex].onClick.AddListener(delegate
                {
                    BuyGun(player.gunSlots[gunSlot],
                        Instantiate(weaponUpgrades[weapon].gameObject).GetComponent<Weapon>(), player);
                });
                weaponIndex++;
                if (weaponIndex >= weaponSlots.Length - 1)
                    break;
            }
        }
    }

    private void ClearWeaponMenu()
    {
        for (var i = 0; i < displayedWeapons.Count; i++) Destroy(displayedWeapons[i]);
        for (var i = 0; i < weaponSlots.Length; i++) weaponSlots[i].gameObject.SetActive(false);

        for (var i = 0; i < buttons.Count; i++) buttons[i].onClick.RemoveAllListeners();
        displayedWeapons.Clear();
    }

    private void AddShopButtons()
    {
        for (var i = 0; i < weaponSlots.Length; i++) buttons.Add(weaponSlots[i].GetComponentInChildren<Button>());
    }

    public void BuyGun(GunSlot slot, Weapon weapon, PlayerClient player)
    {
        player.weaponUpgrades--;
        slot.SetGun(weapon);
        if (player.weaponUpgrades < 1)
        {
            ClearWeaponMenu();
        }
        else
        {
            ClearWeaponMenu();
            DisplayWeaponUpgrades(player);
        }
    }
}