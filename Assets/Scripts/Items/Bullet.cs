using Object_Pool;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;

    private void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IEntity entity))
        {
            entity.TakeDamage(damage, entity);
            BulletPool.Instance.ReturnToPool(this);
        }
    }
}