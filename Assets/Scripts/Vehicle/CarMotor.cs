using UnityEngine;

namespace Vehicle
{
    public class CarMotor : MonoBehaviour
    {
        [SerializeField] private Transform[] wheelObjects;
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float reverseSpeed;
        [SerializeField] private float turnSpeed;
        public Rigidbody sphereRB;
        public float speedMultiplier;

        private float moveInput;

        private void Start()
        {
            sphereRB.transform.parent = null;
        }

        private void FixedUpdate()
        {
            if (moveInput == 0) return;
            sphereRB.AddForce(transform.forward * (moveInput * speedMultiplier), ForceMode.Acceleration);
        }

        public void Thrust(Vector2 controllerInput)
        {
            moveInput = controllerInput.y * (controllerInput.y > 0 ? forwardSpeed : reverseSpeed) +
                        Mathf.Abs(turnSpeed * controllerInput.x) * controllerInput.y;

            transform.position = sphereRB.transform.position;
        }
    }
}