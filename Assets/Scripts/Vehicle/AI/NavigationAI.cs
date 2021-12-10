using System;
using UnityEngine;

namespace Vehicle
{
    public class NavigationAI : MonoBehaviour
    {
        private Vector3 target;
        public float RotationSpeed;
 
        //values for internal use
        private Quaternion lookRotation;
        private Vector3 direction;

        public void SetDestination(Vector3 destination)
        {
            target = destination;
        }

        private void Update()
        {
            direction = (target - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
        }
    }
}