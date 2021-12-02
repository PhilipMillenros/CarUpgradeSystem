using UnityEngine;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;
        private IInputListener InputListener;

        private PlayerControls controls;
        private PlayerControls.ControlsActions playerMovement;

        private Vector2 movementInput;
        private Vector2 mouseInput;
        private void Awake()
        {
            SetSingleton();
            controls = new PlayerControls();
            playerMovement = controls.Controls;
            
            playerMovement.Spacebar.performed += _ => InputListener.JumpAction();
            playerMovement.MouseHorizontal.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
            playerMovement.MouseVertical.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
            playerMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            playerMovement.MouseRightclick.performed += _ => InputListener?.SecondaryAction();
            playerMovement.MouseLeftclick.performed += _ => InputListener?.PrimaryAction();
            playerMovement.F.performed += _ => InputListener?.SpecialAction();
            playerMovement.E.performed += _ => InputListener?.UseAction();
            playerMovement.Tab.performed += _ => InputListener?.SwitchAction();
        }
        private void SetSingleton()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
                Debug.Log($"More than one InputManager in scene");
            }
        }
        private void Update()
        {
            if(InputListener == null)
                return;
            InputListener.Move(movementInput);
            InputListener.LookAround(mouseInput);
        }
        public void SetInputListener(IInputListener inputListener)
        {
            InputListener = inputListener;
        }
        private void OnEnable()
        {
            controls.Enable();
        }
        private void OnDestroy()
        {
            controls.Disable();
        }
    }
}
