

using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector3 bulletSize;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float weaponReloadTimeMultiplier = 1;


    private Vector3 lastPosition = Vector3.zero;
    private bool isShooting;
    private float reloadTime = 0;
    private bool reloaded = true;
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    public void IsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }

    private void Update()
    {
        if (!reloaded)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
                reloaded = true;
        }
        else if (isShooting)
        {
            Shoot();
            reloaded = false;
            reloadTime = playerStats.reloadTime * weaponReloadTimeMultiplier;
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
        CallbackTimer.AddTimer(bulletLifeTime, ()=> bulletPool.ReturnToPool(bullet));
    }
}

public interface IGun
{
    public void IsShooting(bool isShooting);
}
