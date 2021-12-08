using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlot : MonoBehaviour
{
    [SerializeField] private Weapon heldWeapon;
    [SerializeField] private Weapon[] startGunOptions;
 
    public void SetGun(Weapon weapon)
    {
        if (heldWeapon != null)
        {
            Destroy(heldWeapon.gameObject);
        }
        heldWeapon = weapon;
        PositionGunInPlace();
    }

    public Weapon[] GetWeaponUpgrades()
    {
        if (heldWeapon == null)
        {
            return startGunOptions;
        }
        return heldWeapon.upgradeVariants;
    }
    private void PositionGunInPlace()
    {
        heldWeapon.transform.parent = transform;
        heldWeapon.transform.localPosition = Vector3.zero;
        heldWeapon.transform.rotation = transform.rotation;
    }
}
