using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector3 bulletSize;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float reloadTime;
     
    private Vector3 lastPosition = Vector3.zero;
    private bool isShooting;
    private float reloadTimeLeft;
    private bool reloaded = true;

    private void Awake()
    {
        reloadTimeLeft = 0;
    }

    public void IsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }

    private void Update()
    {
        if (!reloaded)
        {
            reloadTimeLeft -= Time.deltaTime;
            if (reloadTimeLeft <= 0)
                reloaded = true;
        }
        else if (isShooting)
        {
            Shoot();
            reloaded = false;
            reloadTimeLeft = reloadTime;
        }
    }

    private void Shoot()
    {
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.damage = damage;
        bullet.speed = bulletSpeed + rb.velocity.magnitude;
        bullet.transform.localScale = bulletSize;
        bullet.gameObject.SetActive(true);
        CallbackTimer.AddTimer(bulletLifeTime, ()=> Destroy(bullet.gameObject));
    }
}

public interface IGun
{
    public void IsShooting(bool isShooting);
}
