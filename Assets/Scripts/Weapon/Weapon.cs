using UnityEngine;
using Vehicle;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected Vector3 bulletSize;
    [SerializeField] protected float bulletLifeTime;

    [SerializeField] protected float weaponReloadTimeMultiplier = 1;
    [SerializeField] private float reloadTime;

    public GameObject displayPrefab;
    public Weapon[] upgradeVariants;
    private bool isShooting;
    protected Rigidbody movement;
    private PlayerClient playerClient;

    private bool reloaded = true;

    protected void Start()
    {
        playerClient = GetComponentInParent<PlayerClient>();
        movement = transform.root.GetComponent<CarMotor>().sphereRB;
        transform.root.GetComponent<CarController>().guns.Add(this);
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

    private void OnDestroy()
    {
        transform.root.GetComponent<CarController>().guns.Remove(this);
    }

    public void IsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }

    protected virtual void Shoot()
    {
    }
}