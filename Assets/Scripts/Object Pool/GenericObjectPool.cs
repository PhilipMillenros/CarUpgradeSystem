using System.Collections.Generic;
using UnityEngine;

namespace Object_Pool
{
    public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;

        private readonly Queue<T> objects = new();
        public static GenericObjectPool<T> Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public T Get()
        {
            if (objects.Count == 0)
                AddObjects(1);
            return objects.Dequeue();
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            objects.Enqueue(objectToReturn);
        }

        private void AddObjects(int count)
        {
            var newObject = Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            newObject.transform.parent = transform;
            objects.Enqueue(newObject);
        }
    }
}