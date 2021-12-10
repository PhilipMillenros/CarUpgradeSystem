using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool;
    [SerializeField] private int maxObstaclesOnField;
    [SerializeField] private float yPosition;
    [SerializeField] private float randomDistanceRange;
    private void Awake()
    {
        Obstacle.OnObstacleDeath += RecycleObstacle;
        for (int i = 0; i < maxObstaclesOnField; i++)
        {
            SpawnNewObstacle();
        }
    }
    private void RecycleObstacle(Obstacle obstacle)
    {
        obstaclePool.ReturnToPool(obstacle);
        SpawnNewObstacle();
    }
    public void SpawnNewObstacle()
    {
        Obstacle obstacle = obstaclePool.Get();
        obstacle.transform.position = new Vector3(Random.Range(0, randomDistanceRange), yPosition, Random.Range(0, randomDistanceRange));
        obstacle.transform.rotation = Quaternion.identity;
        obstacle.gameObject.SetActive(true);
    }
}
