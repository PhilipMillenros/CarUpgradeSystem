using System;
using UnityEngine;

namespace Vehicle
{
    public class Steering : MonoBehaviour
    {
        [SerializeField] private Transform[] frontWheels;
        [SerializeField] private float maxSteeringAngle;
        public float wheelAngle;
        [SerializeField] private float turnBackSpeed = 5f;
        [SerializeField] private float wheelTurningSpeed = 20f;
        [SerializeField] private float maxTurningSpeed = 50f;
        [SerializeField] private float turningSpeed = 0.5f;
        [SerializeField] private SkidMark skidMark;
        [SerializeField] private float skidMarkDelay;

        [SerializeField] private float currentTurnSpeed;
        private Vector2 input;
        private float steering;
        private float timerValue;
        private IMovementInput carController;

        private void Start()
        {
            carController = GetComponent<IMovementInput>();
            if(carController == null)
                Debug.Log($"Missing movement input at {name}");
        }

        private void Update()
        {
            SetSteering();
        }

        public void SetSteering()
        {
            input.x = carController.Horizontal;
            input.y = carController.Vertical;
            if (input.x != 0 || input.y != 0)
            {
                input.x = ConvertToWholeNumber(input.x);
                input.y = ConvertToWholeNumber(input.y);
            }

            SteerCar();
            SteerWheels();
            EmitSkidMarks();
        }

        private float ConvertToWholeNumber(float value)
        {
            value = (int) Mathf.Round(value);
            return value;
        }

        private void SteerWheels()
        {
            if (input.y < 0)
                input.x = -input.x;
            if (input.x == 0)
                wheelAngle = Mathf.Lerp(wheelAngle, 0, Time.deltaTime * turnBackSpeed);
            else
                wheelAngle += wheelTurningSpeed * input.x * Time.deltaTime;
            wheelAngle = Mathf.Clamp(wheelAngle, -maxSteeringAngle, maxSteeringAngle);

            for (var i = 0; i < frontWheels.Length; i++)
                frontWheels[i].localRotation = Quaternion.Euler(0, 0, wheelAngle);
        }

        private void SteerCar()
        {
            if (input.y == 0)
            {
                currentTurnSpeed = 0;
                return;
            }

            if (input.y < 0)
                input.x = -input.x;
            currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, maxTurningSpeed * input.x, turningSpeed) * Time.deltaTime;
            transform.Rotate(0, currentTurnSpeed, 0, Space.World);
        }

        private void EmitSkidMarks()
        {
            if (input.x != 0 && input.y != 0)
                timerValue += Time.deltaTime;
            else
                timerValue = 0;

            if (timerValue >= skidMarkDelay && input.y > 0)
                skidMark.SetSkidEmitter(true);
            else
                skidMark.SetSkidEmitter(false);
        }
    }
}