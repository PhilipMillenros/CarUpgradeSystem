using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGun : Weapon
{
    private void Shoot()
    {
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.damage = damage;
        bullet.speed = bulletSpeed + movement.velocity.magnitude;
        bullet.transform.localScale = bulletSize;
        bullet.gameObject.SetActive(true);
        CallbackTimer.AddTimer(bulletLifeTime, ()=> bulletPool.ReturnToPool(bullet));
    }
}
