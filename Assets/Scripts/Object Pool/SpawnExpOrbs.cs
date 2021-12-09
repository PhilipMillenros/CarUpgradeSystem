using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnExpOrbs : MonoBehaviour
{
    [SerializeField] private int maxExpOrbsOnField;
    [SerializeField] private ExpOrbPool objectPool;
    [SerializeField] private float yPosition;
    [SerializeField] private float randomDistanceRange;
    private void Awake()
    {
        Exp.OnExpPickup += ReCycleOrb;
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
        newOrb.transform.position = new Vector3(Random.Range(0, randomDistanceRange), yPosition, Random.Range(0, randomDistanceRange));
        newOrb.transform.rotation = Quaternion.identity;
        newOrb.gameObject.SetActive(true);
    }
}
