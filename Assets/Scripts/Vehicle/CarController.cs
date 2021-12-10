using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vehicle
{
    public class CarController : MonoBehaviour, IInputListener
    {
        [SerializeField] private CarMotor motor;
        [SerializeField] private Steering steering;
        public List<Weapon> guns = new();
        private Vector2Int input;
        private float primaryActionDelay = 1;
        private bool primaryActionHeld;
        private bool secondaryActionHeld;

        private void Start()
        {
            InputManager.instance.SetInputListener(this);
        }

        public void MoveAction(Vector2 input)
        {
            steering.SetSteering(input);
            motor.Thrust(input);
        }

        public void MouseAxis(Vector2 input)
        {
            //thirdPersonCamera.SetInput(input);
        }

        public void JumpAction()
        {
        }

        public void PrimaryAction(InputAction.CallbackContext ctx)
        {
            for (var i = 0; i < guns.Count; i++) guns[i]?.IsShooting(ctx.control.IsPressed());
        }

        public void SecondaryAction(InputAction.CallbackContext ctx)
        {
        }
    }
}