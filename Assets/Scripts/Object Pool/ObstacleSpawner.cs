using UnityEngine;

namespace Object_Pool
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private ObstaclePool obstaclePool;
        [SerializeField] private int maxObstaclesOnField;
        [SerializeField] private float yPosition;
        [SerializeField] private float randomDistanceRange;

        private void Awake()
        {
            Obstacle.OnObstacleDeath += RecycleObstacle;
            for (var i = 0; i < maxObstaclesOnField; i++) SpawnNewObstacle();
        }

        private void RecycleObstacle(Obstacle obstacle)
        {
            obstaclePool.ReturnToPool(obstacle);
            SpawnNewObstacle();
        }

        public void SpawnNewObstacle()
        {
            var obstacle = obstaclePool.Get();
            obstacle.transform.position = new Vector3(Random.Range(0, randomDistanceRange), yPosition,
                Random.Range(0, randomDistanceRange));
            obstacle.transform.rotation = Quaternion.identity;
            obstacle.gameObject.SetActive(true);
        }
    }
}