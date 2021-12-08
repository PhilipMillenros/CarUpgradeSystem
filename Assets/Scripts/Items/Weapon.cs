using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected BulletPool bulletPool;
    [SerializeField] protected float damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected Vector3 bulletSize;
    [SerializeField] protected float bulletLifeTime;
    [SerializeField] protected Rigidbody movement;
    [SerializeField] protected float weaponReloadTimeMultiplier = 1;

    public Weapon[] upgradeVariants;
    protected bool isShooting;
    protected float reloadTime = 0;
    protected bool reloaded = true;
    protected PlayerClient playerClient;

    protected void Awake()
    {
        playerClient = GetComponentInParent<PlayerClient>();
    }

    public void IsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }

    protected void Update()
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
            reloadTime = playerClient.reloadTime * weaponReloadTimeMultiplier;
        }
    }
    protected void Shoot()
    {
        //Bullet bullet = bulletPool.Get();
        //bullet.transform.position = transform.position;
        //bullet.transform.rotation = transform.rotation;
        //bullet.damage = damage;
        //bullet.speed = bulletSpeed + movement.velocity.magnitude;
        //bullet.transform.localScale = bulletSize;
        //bullet.gameObject.SetActive(true);
        //CallbackTimer.AddTimer(bulletLifeTime, ()=> bulletPool.ReturnToPool(bullet));
    }
}
