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
    protected PlayerCarController PlayerCarController;

    private bool reloaded = true;

    protected void Start()
    {
        playerClient = GetComponentInParent<PlayerClient>();
        movement = transform.root.GetComponent<CarMotor>().sphereRB;
        PlayerCarController = transform.root.GetComponent<PlayerCarController>();
    }

    protected void Update()
    {
        isShooting = PlayerCarController.isShooting;
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
    protected virtual void Shoot()
    {
    }
}