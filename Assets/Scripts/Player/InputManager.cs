using UnityEngine;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;

        private PlayerControls controls;
        private IInputListener InputListener;
        private Vector2 mouseInput;

        private Vector2 movementInput;
        private PlayerControls.ControlsActions playerMovement;

        private void Awake()
        {
            SetSingleton();
            controls = new PlayerControls();
            playerMovement = controls.Controls;
            playerMovement.MouseHorizontal.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
            playerMovement.MouseVertical.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
            playerMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            playerMovement.MouseRightclick.performed += ctx => InputListener?.SecondaryAction(ctx);
            playerMovement.MouseLeftclick.performed += ctx => InputListener?.PrimaryAction(ctx);
        }

        private void LateUpdate()
        {
            if (InputListener == null)
                return;
            InputListener.MoveAction(movementInput);
            InputListener.MouseAxis(mouseInput);
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDestroy()
        {
            controls.Disable();
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
                Debug.Log("More than one InputManager in scene");
            }
        }

        public void SetInputListener(IInputListener inputListener)
        {
            InputListener = inputListener;
        }
    }
}