using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGun : Weapon
{
    private GenericObjectPool<Bullet> bulletPool;
    [SerializeField] private Transform bulletOrigin;

    private void Awake()
    {
        bulletPool = BulletPool.Instance;
    }

    protected override void Shoot()
    {
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = bulletOrigin.position;
        bullet.transform.rotation = bulletOrigin.rotation;
        bullet.damage = damage;
        bullet.speed = bulletSpeed + (movement.velocity.magnitude * bulletOrigin.forward).magnitude;
        bullet.transform.localScale = bulletSize;
        bullet.gameObject.SetActive(true);
        CallbackTimer.AddTimer(bulletLifeTime, ()=> bulletPool.ReturnToPool(bullet));
    }
}
