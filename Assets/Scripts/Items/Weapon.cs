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
    [SerializeField] private float reloadTime = 0;
    
    public Weapon[] upgradeVariants;
    private bool isShooting;
    
    private bool reloaded = true;
    private PlayerClient playerClient;

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
    protected virtual void Shoot(){ }
}
