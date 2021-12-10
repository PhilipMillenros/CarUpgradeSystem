using Object_Pool;
using UnityEngine;

public class SmallGun : Weapon
{
    [SerializeField] private Transform bulletOrigin;
    private GenericObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = BulletPool.Instance;
    }

    protected override void Shoot()
    {
        var bullet = bulletPool.Get();
        bullet.transform.position = bulletOrigin.position;
        bullet.transform.rotation = bulletOrigin.rotation;
        bullet.damage = damage;
        bullet.speed = (movement.velocity + bulletOrigin.forward * bulletSpeed).magnitude;
        bullet.transform.localScale = bulletSize;
        bullet.gameObject.SetActive(true);
        CallbackTimer.AddTimer(bulletLifeTime, () => bulletPool.ReturnToPool(bullet));
    }
}