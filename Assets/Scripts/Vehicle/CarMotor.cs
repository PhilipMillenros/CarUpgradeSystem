using System;
using UnityEngine;

namespace Vehicle
{
    public class CarMotor : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float reverseSpeed;
        [SerializeField] private float turnSpeed;
        public Rigidbody sphereRB;
        public float speedMultiplier;
        private float moveInput;
        private IMovementInput carController;

        private void Awake()
        {
            carController = GetComponent<IMovementInput>();
            if (carController == null)
            {
                Debug.Log($"Missing movement input component at {name}");
            }
            sphereRB.transform.parent = null;
        }

        private void FixedUpdate()
        {
            Thrust();
            if (moveInput == 0) return;
            sphereRB.AddForce(transform.forward * (moveInput * speedMultiplier), ForceMode.Acceleration);
        }
        public void Thrust()
        {
            moveInput = carController.Vertical * (carController.Vertical > 0 ? forwardSpeed : reverseSpeed) +
                        Mathf.Abs(turnSpeed * carController.Horizontal) * carController.Vertical;

            transform.position = sphereRB.transform.position;
        }
    }
}