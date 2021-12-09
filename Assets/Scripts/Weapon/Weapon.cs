using System;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
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

    protected void Start()
    {
        playerClient = GetComponentInParent<PlayerClient>();
        movement = transform.root.GetComponent<CarMotor>().sphereRB;
        transform.root.GetComponent<CarController>().guns.Add(this);
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
    protected virtual void Shoot() { }

    private void OnDestroy()
    {
        transform.root.GetComponent<CarController>().guns.Remove(this);
    }
}
