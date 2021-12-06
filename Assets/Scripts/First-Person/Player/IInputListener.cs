using UnityEngine;

namespace Player
{
    public interface IInputListener
    {
        public void MoveAction(Vector2 input);
        public void MouseAxis(Vector2 input);
        public void JumpAction();
        public void PrimaryAction();
        public void SecondaryAction();
        public void SwitchAction();
        public void SpecialAction();
        public void UseAction();
    }
}
