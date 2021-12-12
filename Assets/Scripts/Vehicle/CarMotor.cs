using System;
using UnityEngine;

namespace Vehicle
{
    public class CarMotor : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float reverseSpeed;
        [SerializeField] private float turnSpeed;
        [HideInInspector] public Rigidbody sphereRb;
        public float speedMultiplier;
        private float moveInput;
        private IMovementInput carController;

        private void Awake()
        {
            sphereRb.transform.parent = null;
        }

        public void SetMotor(IMovementInput carController, Rigidbody sphereRb) 
        {
            this.carController = carController;
            this.sphereRb = sphereRb;
        }
        private void FixedUpdate()
        {
            Thrust();
            if (moveInput == 0) return;
            sphereRb.AddForce(transform.forward * (moveInput * speedMultiplier), ForceMode.Acceleration);
        }
        public void Thrust()
        {
            moveInput = carController.Vertical * (carController.Vertical > 0 ? forwardSpeed : reverseSpeed) +
                        Mathf.Abs(turnSpeed * carController.Horizontal) * carController.Vertical;

            transform.position = sphereRb.transform.position;
        }
    }
}