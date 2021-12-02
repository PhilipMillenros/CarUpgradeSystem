using UnityEngine;

namespace Player
{
    public interface IInputListener
    {
        public void Move(Vector2 input);
        public void LookAround(Vector2 input);
        public void JumpAction();
        public void PrimaryAction();
        public void SecondaryAction();
        public void SwitchAction();
        public void SpecialAction();
        public void UseAction();
    }
}
