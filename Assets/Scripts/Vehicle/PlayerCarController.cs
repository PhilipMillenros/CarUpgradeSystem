using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vehicle
{
    public class PlayerCarController : MonoBehaviour, IInputListener, IMovementInput
    {
        public bool isShooting;
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        private void Start()
        {
            InputManager.instance.SetInputListener(this);
            
        }

        public void MoveAction(Vector2 input)
        {
            Vertical = input.y;
            Horizontal = input.x;
        }

        public void MouseAxis(Vector2 input)
        {
        }

        public void JumpAction()
        {
        }

        public void PrimaryAction(InputAction.CallbackContext ctx)
        {
            isShooting = ctx.control.IsPressed();
        }

        public void SecondaryAction(InputAction.CallbackContext ctx)
        {
        }

        
    }

    public interface IMovementInput
    {
        public float Horizontal { get; }
        public float Vertical { get; }
    }
}