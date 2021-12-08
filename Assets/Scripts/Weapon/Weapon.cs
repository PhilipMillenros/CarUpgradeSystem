using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected BulletPool bulletPool;
    [SerializeField] protected float damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected Vector3 bulletSize;
    [SerializeField] protected float bulletLifeTime;
     
    [SerializeField] protected float weaponReloadTimeMultiplier = 1;
    [SerializeField] private float reloadTime = 0;

    public GameObject displayPrefab;
    public Weapon[] upgradeVariants;
    private bool isShooting;
    protected Rigidbody movement;
    
    private bool reloaded = true;
    private PlayerClient playerClient;

    protected void Awake()
    {
        playerClient = GetComponentInParent<PlayerClient>();
        if (TryGetComponent(out CarMotor motor))
            movement = motor.sphereRB;
        else
            movement = gameObject.AddComponent<Rigidbody>();
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
