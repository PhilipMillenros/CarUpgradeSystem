using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public interface IInputListener
    {
        public void MoveAction(Vector2 input);
        public void MouseAxis(Vector2 input);
        public void PrimaryAction(InputAction.CallbackContext ctx);
        public void SecondaryAction(InputAction.CallbackContext ctx);
    }
}