using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExpSpawner : MonoBehaviour
{
    [SerializeField] private int maxExpOrbsOnField;
    [SerializeField] private ExpOrbPool objectPool;
    [SerializeField] private float yPosition;
    private void Awake()
    {
        Exp.OnExpPickup += ReCycleOrb; //Observer pattern
        for (int i = 0; i < maxExpOrbsOnField; i++)
        {
            SpawnNewOrb();
        }
    }
    private void ReCycleOrb(Exp orb)
    {
        objectPool.ReturnToPool(orb);
        SpawnNewOrb();
    }
    public void SpawnNewOrb()
    {
        Exp newOrb = objectPool.Get();
        newOrb.transform.position = new Vector3(Random.Range(0, 1000), yPosition, Random.Range(0, 1000));
        newOrb.transform.rotation = Quaternion.identity;
        newOrb.gameObject.SetActive(true);
    }
}
